using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField][Range(10, 50)] float damage = 10.0f;

    public bool isHit = false;

    private Animator animator;
    private Rigidbody2D projectileRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.projectileRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.animator.SetBool("IsHit", true);
        this.projectileRigidbody.velocity = Vector3.zero;

        Destroy(gameObject, this.animator.GetCurrentAnimatorStateInfo(0).length - 0.1f);
    }
}
