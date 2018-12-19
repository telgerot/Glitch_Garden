using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnnouncementText : MonoBehaviour {

    [SerializeField] float warningWaitTime = 2f; // How long should the announcement text be up
    [SerializeField] AudioClip errorAudioClip; // The error sound
    [SerializeField] [Range(0, 1)] float errorAudioVolume = 0.5f; // Error sound volume
    private Coroutine wipeText = null; // Used for detecting whether an error message is up already

    TextMeshProUGUI announcementText;

    void Start () {
        announcementText = GetComponent<TextMeshProUGUI>();  
        announcementText.text = " ";

    }
	
	public void WarningNotEnoughStars()
    {        
        if (wipeText != null) //i.e. is their an error message there already?
        {
            StopCoroutine(wipeText); // If there's an error message, this will interrupt its erasal procedure
        }

        AudioSource.PlayClipAtPoint(errorAudioClip, Camera.main.transform.position, errorAudioVolume);
        announcementText.text = "Not enough stars, yo!";
        wipeText = StartCoroutine(WipeText());       
    }

    IEnumerator WipeText() //Clears the announcement text bar after X seconds
    {
        yield return new WaitForSeconds(warningWaitTime);
        announcementText.text = " ";
        wipeText = null;
    }
}
