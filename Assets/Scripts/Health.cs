using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField][Range(10f, 100f)] int health = 30;

    Animator animator;
    Rigidbody2D enemyRigidbody;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.enemyRigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void DealDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            this.animator.SetBool("IsDestroyed", true);

            Destroy(gameObject, this.animator.GetCurrentAnimatorStateInfo(0).length + 0.6f);
        }
    }
}
