using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfLivingAttackers;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;


    public void AttackerSpawned()
    {
        numberOfLivingAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfLivingAttackers--;
        if (numberOfLivingAttackers <= 0 && levelTimerFinished)
        {
            print("Show win now");
            winLabel.SetActive(true);
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.spawn = false;
        }
    }


}
