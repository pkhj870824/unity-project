using System;
using System.IO;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Zombie : LivingEntitiy
{
    public enum State
    {
        Idle,
        Trace,
        Attack,
        Die,
    }

    public Transform target;
    public LayerMask targetLayer;
    public ZombieData zombieData;

    public float traceDistance = 10f;
    public float attackDistance = 1.5f;

    public ParticleSystem bloodEffect;
    public Collider zombieCollider;
    public Renderer zombieRenderer;
    public AudioClip hitClip;
    public AudioClip deathClip;
    private NavMeshAgent agent;
    private Animator zombieAnimator;
    private AudioSource zombieAudioSource;
    public float attackTime = 1.5f;

    public float damage = 10;
    private float lastAttackTime;
    private State currentState;
    public static readonly int IdHasTarget = Animator.StringToHash("HasTarget");
    public static readonly int IdDie = Animator.StringToHash("HasTarget");

    public State CurrentState
    {
        get => currentState;
        set
        {
            currentState = value;
            Debug.Log(currentState);
            switch (currentState)
            {
                case State.Idle:
                    zombieAnimator.SetBool("HasTarget", false);
                    agent.isStopped = true;
                    break;
                case State.Trace:
                    zombieAnimator.SetBool("HasTarget", true);
                    agent.isStopped = false;
                    break;
                case State.Attack:
                    zombieAnimator.SetBool("HasTarget", false);
                    agent.isStopped = true;
                    break;
                case State.Die:
                    agent.isStopped = true;
                    zombieAnimator.SetTrigger(IdDie);
                    zombieCollider.enabled = false;
                    zombieAudioSource.PlayOneShot(deathClip);
                    break;
            }
        }
    }
    public void Setup(ZombieData data)
    {
        startingHealth = data.maxHp;
        damage = data.damage;
        agent.speed = data.speed;
        zombieRenderer.material.color = data.skinColor;
    }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponent<Animator>();
        zombieAudioSource = GetComponent<AudioSource>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        agent.enabled = true;



        if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 10f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
        }

        zombieCollider.enabled = true;
        CurrentState = State.Idle;
    }

    private void OnDisable()
    {
        if (agent.isOnNavMesh)
        {
            agent.ResetPath();
        }
    }

    public void Attack()
    {
        if (CurrentState == State.Attack &&
            Time.time >= lastAttackTime + attackTime)
        {
            lastAttackTime = Time.time;

            IDamageable damageable = target.GetComponent<IDamageable>();
            var hitNormal = (transform.position - target.position).normalized;
            damageable.OnDamage(damage, target.position, hitNormal);
        }
    }

    private void Update()
    {
        switch (CurrentState)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.Trace:
                UpdateTrace();
                break;
            case State.Attack:
                UpdateAttack();
                break;
            case State.Die:
                UpdateDie();
                break;
        }
    }

    private void UpdateDie()
    {

    }

    private void UpdateAttack()
    {
        if (target == null)
        {
            CurrentState = State.Idle;
            return;
        }

        if (Vector3.Distance(transform.position, target.position) > attackDistance)
        {
            CurrentState = State.Trace;
            return;
        }

        Attack();
    }

    private void UpdateTrace()
    {
        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            CurrentState = State.Attack;
            return;
        }

        if (target == null || Vector3.Distance(transform.position, target.position) > traceDistance)
        {
            target = null;
            CurrentState = State.Idle;
            return;
        }

        agent.SetDestination(target.position);
    }

    private void UpdateIdle()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) < traceDistance)
        {
            CurrentState = State.Trace;
            return;
        }

        target = FindTarget(traceDistance);
    }

    private Transform FindTarget(float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, targetLayer);
        Transform closet = null;
        float closetDistance = float.MaxValue;

        for (int i = 0; i < colliders.Length; ++i)
        {
            float distance = Vector3.Distance(transform.position, colliders[i].transform.position);
            if (distance < closetDistance)
            {
                closetDistance = distance;
                closet = colliders[i].transform;
            }
        }
        return closet;
    }
    public override void OnDamage(float damage, Vector3 hitpoint, Vector3 hitnormal)
    {
        if (IsDead)
        {
            return;
        }
        base.OnDamage(damage, hitpoint, hitnormal);
        zombieAudioSource.PlayOneShot(hitClip);
        bloodEffect.transform.position = hitpoint;
        bloodEffect.transform.forward = hitnormal;
        bloodEffect.Play();

    }


    public override void Die()
    {
        base.Die();

        CurrentState = State.Die;
        zombieAnimator.SetTrigger("Die");

    }
}
