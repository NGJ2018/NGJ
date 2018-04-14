using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Clickable {

    public AudioClip audioClip;

    public override void Interact(){
        //Do something with audioClip
        Debug.Log("MY NAME: "+this.gameObject.name);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
