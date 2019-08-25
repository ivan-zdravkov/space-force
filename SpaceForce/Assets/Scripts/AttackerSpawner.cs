using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] [Range(1, 2)] float minSpawn = 1.5f;
    [SerializeField] [Range(5, 10)] float maxSpawn = 7.5f;
    [SerializeField] Attacker attackerPrefab;

    IEnumerator Start()
    {
        this.attackerPrefab.GetComponent<SpriteRenderer>().sortingOrder = 5;

        while (this.spawn)
        {
            yield return new WaitForSeconds(Random.Range(this.minSpawn, this.maxSpawn));

            this.Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        Instantiate(attackerPrefab, transform.position, Quaternion.identity);
    }
}
