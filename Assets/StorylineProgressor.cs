using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorylineProgressor : Clickable {

	public int StorylineID;


	public override void Interact(){
		GameController.Singleton.ProgressStoryline (StorylineID);
	}
}
