using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class PsychologyManager : MonoBehaviour {

	public static PsychologyManager Singleton;

	private bool Active = false;

	private RigidbodyFirstPersonController player;
	public Transform CamPos;

	private Transform prevTrans;

	private void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<RigidbodyFirstPersonController>();
		Active = false;
		Singleton = this;
	}



	private void Update(){
		if (Active) {
			print ("Active");
			if (!GameController.Singleton.AS.isPlaying) {
				Active = false;
				Camera.main.transform.position = prevTrans.position;
				Camera.main.transform.rotation = prevTrans.rotation;
				player.IsPsych = false;
				player.enabled = true;
				GameController.Singleton.ProgressStoryLine (true);	
			}
		}
	}

	public void BeginPsychInteraction(){
		try{
			BlinkController.OnBlinkEnd -= BeginPsychInteraction;
			Active = true;
			player.IsPsych = true;
			player.enabled = false;
			prevTrans = Camera.main.transform;
			Camera.main.transform.position = CamPos.position;
			Camera.main.transform.rotation = CamPos.rotation;
		} catch(System.Exception e){
			print (e);
			Debug.Log ("Could not unsubscribe");
		}
	}
}
