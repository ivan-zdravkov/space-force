using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * this.currentSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        if (this.currentSpeed != speed)
        {

            this.currentSpeed = speed;
        }
    }
}
