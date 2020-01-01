using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] [Range(0.1f, 2.0f)] float shootInterval = 3.5f;
    [SerializeField] [Range(0.1f, 0.5f)] float randomFactor = 0.25f;
    [SerializeField] float damage;

    private float shotCounter;
    private float currentSpeed = 0f;

    GameObject currentTarget;

    void Start()
    {
    }

    void Update()
    {
        if (this.currentTarget == null)
            this.Move();
        else
            this.StartAttacking();
    }

    public void SetMovementSpeed(float speed)
    {
        if (this.currentSpeed != speed)
            this.currentSpeed = speed;
    }

    private void ResetShootCounter()
    {
        this.shotCounter = UnityEngine.Random.Range(this.shootInterval - this.randomFactor, this.shootInterval + this.randomFactor);
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * this.currentSpeed);
    }

    private void StartAttacking()
    {
        this.shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            this.Attack();
            this.ResetShootCounter();
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject other = otherCollider.gameObject;

        if (other.GetComponent<Defender>())
            this.currentTarget = other;
    }

    private void Attack()
    {
        if (this.currentTarget)
        {
            Vector3 shootPosition = transform.position;

            shootPosition.x -= 0.95f;
            shootPosition.y -= 0.01f;

            EnemyAttack enemyAttack = Instantiate(
                original: this.enemyAttack,
                position: shootPosition,
                rotation: Quaternion.identity
            ) as EnemyAttack;

            enemyAttack.transform.parent = transform;

            this.Damage();
        }
    }

    private void Damage()
    {
        if (this.currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();

            if (health)
                health.DealDamage(this.damage);
        }
    }
}