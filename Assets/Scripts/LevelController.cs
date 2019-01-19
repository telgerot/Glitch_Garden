using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfLivingAttackers;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] AudioClip winSound;
    [SerializeField] [Range(0, 1)] float winSoundVolume = 0.1f;
    [Tooltip("Time in seconds")][SerializeField] float levelTransitionTime = 3f;


    public void AttackerSpawned()
    {
        numberOfLivingAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfLivingAttackers--;
        if (numberOfLivingAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
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

    public void TurnOnFailCanvas()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator HandleWinCondition()
    {
        winCanvas.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, winSoundVolume);
        yield return new WaitForSeconds(levelTransitionTime);
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }


}
