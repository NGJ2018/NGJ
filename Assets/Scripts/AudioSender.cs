using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioChorusFilter))]
public class AudioSender : Clickable {

	private AudioSource AS;
	private AudioChorusFilter ACF;
	private float Freq;

	void Start () {
		AS = GetComponent<AudioSource> ();
		ACF = GetComponent<AudioChorusFilter> ();
		print (this.GetType ());

		Freq = UnityEngine.Random.Range (1, 10);

		ACF.rate = 7.4f;
		ACF.depth = .7f;
		ACF.delay = 70;
		ACF.wetMix1 = .5f;
		ACF.wetMix2 = .5f;


		ACF.enabled = this.GetType () != typeof(StorylineProgressor);


		AS.spatialBlend = 1.0f;

		AS.Play ();
	}

	public void Update(){
		ACF.depth = (float)Math.Sin (Time.time / Freq)/2 + 0.5f;

	}

	public override void Interact(){
		TurnOff ();
	}

	public void TurnOff (){
		AS.Stop ();
	}
}
