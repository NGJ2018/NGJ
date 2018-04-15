using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtYlocked : MonoBehaviour {

    public GameObject target;

	void Update () {
		target = Camera.main.gameObject;
		if (target != null) {
			transform.LookAt (transform.position + new Vector3 (target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z));
		}
	}
}
