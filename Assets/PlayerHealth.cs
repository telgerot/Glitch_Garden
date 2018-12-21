using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int playerHealth = 3;
    [SerializeField] float gameOverScreenDelay = 2f;

    [SerializeField] AudioClip gameOverClip;
    [SerializeField] float gameOverSoundVolume;

    Text playerHealthText;
    AudioSource gameOverSound;

    void Start()
    {
        playerHealthText = GetComponent<Text>();
        gameOverSound = GetComponent<AudioSource>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        playerHealthText.text = playerHealth.ToString();
        if (playerHealth <= 0)
        {
            PlayDefeatSequence();
            StartCoroutine(GameOver());
        }
    }

    private void PlayDefeatSequence()
    {
        if (!gameOverSound.isPlaying) //so the sound effect doesn't layer
        {
            gameOverSound.PlayOneShot(gameOverClip);
        }
    }

    public void SubtractPlayerHealth(int playerDamageReceived)
    {
        playerHealth -= playerDamageReceived;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
        UpdateDisplay();
    }

    IEnumerator GameOver()
    {     
        yield return new WaitForSeconds(gameOverScreenDelay);
        SceneManager.LoadScene(1);
    }
}
