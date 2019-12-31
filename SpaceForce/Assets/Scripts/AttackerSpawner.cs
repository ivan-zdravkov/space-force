using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] [Range(1, 2)] float minSpawn = 1.5f;
    [SerializeField] [Range(5, 10)] float maxSpawn = 7.5f;
    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        Attacker attacker = this.GetAttacker();

        attacker.GetComponent<SpriteRenderer>().sortingOrder = 5;

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
        Attacker attacker = this.GetAttacker(); 

        attacker = Instantiate(
            original: attacker,
            position: transform.position,
            rotation: Quaternion.identity
        ) as Attacker;

        attacker.transform.parent = transform;
    }

    private Attacker GetAttacker()
    {
        int i = Random.Range(0, this.attackerPrefabs.Length - 1);

        return this.attackerPrefabs[i];
    }
}
