using System;
using System.Collections;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading,
    }
    public State CurrentState { get; private set; }

    public Transform fireTransform;

    public ParticleSystem muzzleFlashEffect;
    public ParticleSystem shellEjectffect;
    private LineRenderer bulletLineRenderer;
    private AudioSource gunAudioPlayer;
    public GunData gunData;

    private float fireDistance = 50f;

    private int ammoRemain;
    private int magAmmo;
    private float lastFireTime;
    public UiManager uiManager;

    private void Awake()
    {
        bulletLineRenderer = GetComponent<LineRenderer>();
        gunAudioPlayer = GetComponent<AudioSource>();

        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }
    private void OnEnable()
    {
        ammoRemain = gunData.startAmmoRemain;
        magAmmo = gunData.magCapacity;
        uiManager.SetAmmoText(magAmmo, ammoRemain);

        CurrentState = State.Ready;
        lastFireTime = 0f;
    }

    public void Fire()
    {
        if (CurrentState == State.Ready && Time.time >= lastFireTime + gunData.timeBetFire)
        {
            lastFireTime = Time.time;
            Shoot();
        }
    }

    public LayerMask targetLayer;

    private void Shoot()
    {
        Vector3 hitposition;

        Ray ray = new Ray(fireTransform.position, fireTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, fireDistance, targetLayer))
        {
            hitposition = hit.point;

            IDamageable target = hit.collider.GetComponent<IDamageable>();
            if (target != null)
            {
                target.OnDamage(gunData.damage, hit.point, hit.normal);
            }
        }
        else
        {
            hitposition = fireTransform.position + fireTransform.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitposition));

        magAmmo--;
        uiManager.SetAmmoText(magAmmo, ammoRemain);

        if (magAmmo == 0)
        {
            CurrentState = State.Empty;
        }

    }


    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        muzzleFlashEffect.Play();
        shellEjectffect.Play();
        gunAudioPlayer.PlayOneShot(gunData.shotClip);

        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(0.03f);
        bulletLineRenderer.enabled = false;
    }

    private IEnumerator ReloadRoutine()
    {
        CurrentState = State.Reloading;
        gunAudioPlayer.PlayOneShot(gunData.reloadClip);
        yield return new WaitForSeconds(gunData.reloadTime);
        int reloadAmmo = gunData.magCapacity - magAmmo;

        if (ammoRemain < reloadAmmo)
        {
            reloadAmmo = ammoRemain;
        }

        magAmmo += reloadAmmo;
        ammoRemain -= reloadAmmo;

        CurrentState = State.Ready;
        uiManager.SetAmmoText(magAmmo, ammoRemain);


    }


    public bool Reload()
    {
        if (ammoRemain == 0 || magAmmo == gunData.magCapacity || CurrentState == State.Reloading)
        {
            return false;
        }
        StartCoroutine(ReloadRoutine());
        CurrentState = State.Reloading;
        return true;
    }
}
