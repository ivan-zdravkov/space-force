using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;

    GameObject currentTarget;

    void Start()
    {
    }

    void Update()
    {
        if (this.currentTarget == null)
            transform.Translate(Vector2.left * Time.deltaTime * this.currentSpeed);
        else
            this.Attack(this.currentTarget);
    }

    public void SetMovementSpeed(float speed)
    {
        if (this.currentSpeed != speed)
            this.currentSpeed = speed;
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
    }
}
