using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StorylineProgressor : AudioSender {

	public int StorylineID;

	public override void Interact(){
		base.Interact ();
		GameController.Singleton.ProgressStoryline (StorylineID);
		BlinkController.OnBlinkEnd += PsychologyManager.Singleton.BeginPsychInteraction;
		print ("Clicked interact");
	}
}
