using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 2.0f)] float shootInterval = 2.5f;
    [SerializeField] [Range(0.1f, 0.5f)] float randomFactor = 0.15f;

    public void Fire()
    {
        return;
    }
}
