using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Range(1f, 5f)] [SerializeField] float minSpeed = 3.5f;
    [Range(5f, 10f)] [SerializeField] float maxSpeed = 7.5f;

    [Range(0.5f, 2.5f)] [SerializeField] float minShrink = 1.75f;
    [Range(2.5f, 5.0f)] [SerializeField] float maxShrink = 3.25f;

    private const float speedScale = 0.2f;
    private const float shrinkScale = 0.0085f;

    private float speed;
    private float shrink;
    private Vector3 direction;

    private Vector3 destroyVector = new Vector3(0.01f, 0.01f, 0.01f);

    void Start()
    {
        this.speed = UnityEngine.Random.Range(this.minSpeed, this.maxSpeed);
        this.shrink = UnityEngine.Random.Range(this.minShrink, this.maxShrink);
        this.direction = UnityEngine.Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        this.FlyAway();
        this.Shrink();

        if (this.ShouldDestroy())
            Destroy(this.gameObject);
    }

    private bool ShouldDestroy()
    {
        return Math.Abs(this.transform.localScale.x) < this.destroyVector.x ||
            Math.Abs(this.transform.localScale.y) < this.destroyVector.y;
    }

    private void FlyAway()
    {
        this.transform.position += this.direction * this.speed * speedScale * Time.deltaTime;
    }

    private void Shrink()
    {
        this.transform.localScale -= new Vector3(1f, 1f, 1f) * this.shrink * shrinkScale * Time.deltaTime;
    }
}
