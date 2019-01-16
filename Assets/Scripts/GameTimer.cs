using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")][SerializeField] float levelTime = 10f;
    public bool timerFinished;

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
    }
}
