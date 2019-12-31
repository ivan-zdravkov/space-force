using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField][Range(10f, 100f)] float health = 30f;

    Animator animator;
    Rigidbody2D enemyRigidbody;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.enemyRigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void DealDamage(float damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            this.animator.SetBool("IsDestroyed", true);

            Destroy(gameObject, this.animator.GetCurrentAnimatorStateInfo(0).length + 0.6f);
        }
    }
}
