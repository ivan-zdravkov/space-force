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
            transform.Translate(Vector2.left * Time.deltaTime * this.currentSpeed);
        else
            this.CountDownAndShoot(this.currentTarget);
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

    private void CountDownAndShoot(GameObject currentTarget)
    {
        this.shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            this.Attack(currentTarget);

            this.ResetShootCounter();
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject other = otherCollider.gameObject;

        if (other.GetComponent<Defender>() != null)
            this.Target(other);
    }

    public void Target(GameObject target)
    {
        this.currentTarget = target;
    }

    private void Attack(GameObject currentTarget)
    {
        Vector3 shootPosition = transform.position;

        shootPosition.x -= 0.95f;
        shootPosition.y -= 0.01f;

        Instantiate(
            original: enemyAttack,
            position: shootPosition,
            rotation: Quaternion.identity
        );
    }
}
