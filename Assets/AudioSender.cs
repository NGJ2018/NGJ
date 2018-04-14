using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSender : Clickable {

	private AudioSource AS;

	void Start () {
		AS = GetComponent<AudioSource> ();
		AS.Play ();
	}

	public override void Interact(){
		TurnOff ();
	}

	public void TurnOff (){
		AS.Stop ();
	}
}
