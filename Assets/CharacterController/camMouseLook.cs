﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class camMouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5f;
    public float smoothing = 2f;
    GameObject character;
    PostProcessingProfile blurry;


    public bool isBlurry = true;
    
	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
        blurry = GetComponent<PostProcessingBehaviour>().profile;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        if (isBlurry)
        {
            blurry.depthOfField.enabled = true;
            blurry.motionBlur.enabled = true;
        } else
        {
            blurry.depthOfField.enabled = false;
            blurry.motionBlur.enabled = false;
        }
	}
}