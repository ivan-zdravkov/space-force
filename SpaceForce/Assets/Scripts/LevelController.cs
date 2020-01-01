using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackerSpawned()
    {
        this.numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        this.numberOfAttackers--;
        
        if (this.numberOfAttackers <= 0 && this.levelTimerFinished)
        {

        }
    }

    public void FinishTimer()
    {
        this.levelTimerFinished = true;

        this.StopSpawners();
    }

    private void StopSpawners()
    {
        foreach(AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawning();
        }
    }
}