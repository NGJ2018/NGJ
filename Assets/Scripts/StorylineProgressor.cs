using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorylineProgressor : AudioSender {

	public int StorylineID;

	public override void Interact(){
		base.Interact ();
		GameController.Singleton.ProgressStoryline (StorylineID);
	}
}
