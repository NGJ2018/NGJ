using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Clickable {

    public AudioClip audioClip;
    private AudioSource audioSource;
    private bool play;

    public override void Interact(){
        //Do something with audioClip
        Debug.Log("MY NAME: "+this.gameObject.name);
        clickedOnObject();
    }

    public void clickedOnObject(){
        //Do something with audio

        //Mute
        audioSource.mute = true;
        play = false;
    }

    // Use this for initialization
    void Start () {
        play = true;
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        StartCoroutine(playSound(2.5f));

    }

    public IEnumerator playSound(float waitTime){
        if (play){
            yield return new WaitForSeconds(waitTime);
            audioSource.Play();
            StartCoroutine(playSound(waitTime));
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
