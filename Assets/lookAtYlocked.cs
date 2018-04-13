using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtYlocked : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform, Vector3.up);
	}
}
