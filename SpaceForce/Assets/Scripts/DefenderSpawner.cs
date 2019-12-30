using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        this.SpawnDefender();
    }

    private void SpawnDefender()
    {
        GameObject defender = Instantiate(
            original: this.defender,
            position: transform.position,
            rotation: Quaternion.Euler(new Vector3(0, 0, 270))
        ) as GameObject;
    }
}
