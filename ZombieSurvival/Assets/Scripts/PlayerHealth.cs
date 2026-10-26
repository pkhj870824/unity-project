using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntitiy
{
    public readonly static int IdDie = Animator.StringToHash("Die");
    public Image uiHealth;

    public AudioClip hitClip;
    public AudioClip deathClip;

    private AudioSource playerAudioSource;
    private Animator playerAnimator;

    private PlayerMovement playerMovement;
    private PlayerShooter playerInput;

    private void Awake()
    {
        playerAudioSource = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerMovement.enabled = true;
        playerInput.enabled = true;

        uiHealth.gameObject.SetActive(true);
        uiHealth.fillAmount = Health / startingHealth;
    }



    public override void OnDamage(float damage, Vector3 hitpoint, Vector3 hitNormal)
    {
        if (!IsDead)
        {
            playerAudioSource.PlayOneShot(hitClip);
        }

        base.OnDamage(damage, hitpoint, hitNormal);
        uiHealth.fillAmount = Health / startingHealth;
    }

    public override void Die()
    {
        base.Die();

        playerAnimator.SetTrigger(IdDie);
        playerAudioSource.PlayOneShot(deathClip);

        playerMovement.enabled = false;
        playerInput.enabled = false;

        uiHealth.gameObject.SetActive(false);

    }
}
