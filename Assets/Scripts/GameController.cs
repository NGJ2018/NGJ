using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {

	public static GameController Singleton;


	public delegate void SLProgression(int id);
	public static event SLProgression OnProgression;


	public AudioSource AS;

	public List<AudioClip> Stories;
	private Queue<AudioClip> AudioQueue;

	public int CurrentStory;


	public void Start(){
		AudioQueue = new Queue<AudioClip> ();
		AS.loop = false;
		AS.spatialBlend = .0f;

		CurrentStory = -1;
		Singleton = this;

		OnProgression += EnqStorySound;
	}

	public void Update(){
		if(!AS.isPlaying && AudioQueue.Count > 0) {
			AS.clip = AudioQueue.Dequeue ();
			AS.Play ();
		}
	}

	public void ProgressStoryline(int id){
		if (id == CurrentStory + 1 && id < Stories.Count) {
			++CurrentStory;
			if (OnProgression != null) {
				OnProgression (CurrentStory);
			}
		}
	}

	public void EnqueueSound(AudioClip clip){
		AudioQueue.Enqueue (clip);
	}

	void EnqStorySound(int id){
		EnqueueSound (Stories [id]);
	}

}
