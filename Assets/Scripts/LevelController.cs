using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfLivingAttackers;
    GameTimer gameTimer;

    private void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
    }

    private void Update()
    {
        CheckTimerAndStopSpawners();
        CheckIfLevelPassed();
    }

    private void CheckTimerAndStopSpawners()
    {
        if (gameTimer.timerFinished)
        {
            var spawners = FindObjectsOfType<AttackerSpawner>();
            foreach (AttackerSpawner spawner in spawners)
            {
                spawner.spawn = false;
            }
        }
    }

    private void CheckIfLevelPassed()
    {
        numberOfLivingAttackers = FindObjectsOfType<Attacker>().Length;

        if (gameTimer.timerFinished && numberOfLivingAttackers == 0)
        {
            print("Game over man");
        }
    }
}
