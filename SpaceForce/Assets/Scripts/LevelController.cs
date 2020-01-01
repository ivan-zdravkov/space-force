using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 5f;
    [SerializeField] GameObject winLabel;
    [SerializeField] AudioClip winSound;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        this.winLabel.SetActive(false);
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
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        this.winLabel.SetActive(true);

        AudioSource.PlayClipAtPoint(this.winSound, transform.position);

        yield return new WaitForSeconds(this.waitToLoad);

        FindObjectOfType<LevelLoader>().LoadNextScene();
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