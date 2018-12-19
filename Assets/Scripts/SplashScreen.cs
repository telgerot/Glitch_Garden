using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

    [SerializeField] AudioClip splashAudio;
    [SerializeField] [Range(0, 1)] float splashAudioVolume = 0.1f;
    // Use this for initialization
    void Start () {
        AudioSource.PlayClipAtPoint(splashAudio, Camera.main.transform.position, splashAudioVolume);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
