using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 2.0f)] float shootInterval = 1.5f;
    [SerializeField] [Range(0.1f, 0.5f)] float randomFactor = 0.15f;
    [SerializeField] [Range(0.5f, 5.0f)] float projectileSpeed = 2f;
    [SerializeField] Projectile projectile;
    [SerializeField] float damage;

    private float shotCounter;

    void Start()
    {
        this.ResetShoutCounter();
    }

    void Update()
    {
        this.CountDownAndShoot();
    }

    private void ResetShoutCounter()
    {
        this.shotCounter = UnityEngine.Random.Range(this.shootInterval - this.randomFactor, this.shootInterval + this.randomFactor);
    }

    private void CountDownAndShoot()
    {
        this.shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            this.Fire();
            this.ResetShoutCounter();
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(
            original: this.projectile.gameObject,
            position: this.transform.position,
            rotation: this.projectile.transform.rotation
        ) as GameObject;

        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(
            x: this.projectileSpeed,
            y: 0
        );
    }
}
