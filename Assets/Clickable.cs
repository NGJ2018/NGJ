using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour {

    public abstract void Interact();

    public void Hover(){

    }
	public void OnGUI(){
		if (GUI.Button (new Rect (new Vector2 (100, 100), new Vector2 (100, 20)), "interact")) {
			Interact ();
		}
	}
}
