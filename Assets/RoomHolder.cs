using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHolder : MonoBehaviour {

	public GameObject SpawnPoint;

	public RoomHolder NextRoom;

	public bool PsychFirst;

	/*

	private List<GameObject> Clickables;



	public void OnEnable(){
		Clickables = new List<GameObject> ();
		foreach (Clickable c in transform.GetComponentsInChildren<Clickable> ()) {
			Clickables.Add (c.gameObject);
		}
		DisableSound ();
	}

	public void DisableSound(){
		foreach (GameObject go in Clickables) {
			go.SetActive (false);
		}
	}

	public void ActivateSound(){
		foreach (GameObject go in Clickables) {
			go.SetActive (true);
		}
	}
	*/
}