using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] [Range(1, 5)] float minSpawn = 5f;
    [SerializeField] [Range(5, 20)] float maxSpawn = 15f;
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

    public void StopSpawning()
    {
        this.spawn = false;
    }

    private void Spawn()
    {
        if (this.spawn)
        {
            Attacker attacker = this.GetAttacker();

            attacker = Instantiate(
                original: attacker,
                position: transform.position,
                rotation: Quaternion.identity
            ) as Attacker;

            attacker.transform.parent = transform;
        }
    }

    private Attacker GetAttacker()
    {
        int i = Random.Range(0, this.attackerPrefabs.Length - 1);

        return this.attackerPrefabs[i];
    }
}
