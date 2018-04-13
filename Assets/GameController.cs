using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController Singleton;


	public delegate void SLProgression(int id);
	public static event SLProgression OnProgression;

	public int CurrentStory = 0;


	public void Start(){
		CurrentStory = 0;
		Singleton = this;
	}

	public void ProgressStoryline(int id){
		if (id == CurrentStory + 1) {
			++CurrentStory;
			if (OnProgression != null) {
				OnProgression (CurrentStory);
			}
		}
	}
}
