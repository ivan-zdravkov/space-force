using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;

    float minSpawn;
    float maxSpawn;

    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        SetSpawnTimers();
            
        Attacker attacker = this.GetAttacker();

        attacker.GetComponent<SpriteRenderer>().sortingOrder = 5;

        while (this.spawn)
        {
            yield return new WaitForSeconds(Random.Range(this.minSpawn, this.maxSpawn));

            this.Spawn();
        }
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

    private void SetSpawnTimers()
    {
        switch (PlayerPrefsController.Difficulty)
        {
            case 0:
            default:
                this.minSpawn = 7.5f;
                this.maxSpawn = 12.5f;
                break;
            case 1:
                this.minSpawn = 5f;
                this.maxSpawn = 10f;
                break;
            case 2:
                this.minSpawn = 2.5f;
                this.maxSpawn = 7.5f;
                break;
        }
    }
}
