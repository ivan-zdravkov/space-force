using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float walkSpeed = 1f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animatorInfo = this.animator.GetCurrentAnimatorStateInfo(SortingLayer.NameToID("Default"));

        transform.Translate(Vector2.left * Time.deltaTime * this.walkSpeed);
    }
}
