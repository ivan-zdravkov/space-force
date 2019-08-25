using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;

    private Animator animator;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo animatorInfo = this.animator.GetCurrentAnimatorStateInfo(SortingLayer.NameToID("Default"));

        transform.Translate(Vector2.left * Time.deltaTime * this.currentSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        if (this.currentSpeed != speed)
        {
            if (this.currentSpeed == 0)
                transform.Translate(-0.1f, 0, 0);

            this.currentSpeed = speed;
        }
    }
}
