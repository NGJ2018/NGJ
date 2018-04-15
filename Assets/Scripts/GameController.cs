using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {

	public static GameController Singleton;


	public delegate void SLProgression(int id);
	public static event SLProgression OnProgression;

	private LevelChangeScript LCS;

	public AudioSource AS;

	public List<AudioClip> Stories;
	private Queue<AudioClip> AudioQueue;

	public int CurrentStory;


	public void Start(){
		LCS = GetComponent<LevelChangeScript> ();
		AudioQueue = new Queue<AudioClip> ();
		AS.loop = false;
		AS.spatialBlend = .0f;

		CurrentStory = -1;
		Singleton = this;

		OnProgression += (id) => ++CurrentStory;
		OnProgression += EnqStorySound;
	}

	public void Update(){
		if(!AS.isPlaying && AudioQueue.Count > 0) {
			AS.clip = AudioQueue.Dequeue ();
			AS.Play ();
		}
	}


	private void BlinkWrapper(){
		OnProgression (CurrentStory); 
		BlinkController.OnBlinkEnd -= BlinkWrapper;
	}

	public void ProgressStoryline(int id){
		if (id == CurrentStory + 1 && id < Stories.Count) {
			if (OnProgression != null) {
				BlinkController.OnBlink += LCS.changeLevel;
				BlinkController.OnBlinkEnd += BlinkWrapper;
				BlinkController.Singleton.InitiateBlink ();
			}
		}
	}

	public void ProgressStoryLine(bool changelevel = false){
		if (CurrentStory + 1 < Stories.Count) {
			if (OnProgression != null) {
				OnProgression (CurrentStory);
				if (changelevel) {
					BlinkController.OnBlink += LCS.changeLevel;
					BlinkController.OnBlinkEnd += BlinkWrapper;
					BlinkController.Singleton.InitiateBlink ();
				}
			}
		}
	}

	public void EnqueueSound(AudioClip clip){
		AudioQueue.Enqueue (clip);
	}

	void EnqStorySound(int id){
		Debug.Log ("SoundID: " + id.ToString());

		EnqueueSound (Stories [++id]);
	}


}
