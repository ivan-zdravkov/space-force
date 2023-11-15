using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    [SerializeField][Range(0.1f, 2.0f)] float rotateSpeed = 1f;

    Transform top;
    Transform bottom;

    void Start()
    {
        this.top = transform.Find("Top");
        this.bottom = transform.Find("Bottom");
    }

    void Update()
    {
        transform.RotateAround(
            point: transform.position,
            axis: Vector3.back,
            angle: Time.deltaTime * this.rotateSpeed * 30);

        this.top.position = new Vector2(0f, 0.3f);
        this.bottom.position = new Vector2(0f, -0.3f);
    }
}
