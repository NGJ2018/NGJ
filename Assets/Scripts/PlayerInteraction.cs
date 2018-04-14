using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public Camera mainCamera;
    public float distance;
    public GameObject old_gameobject;
    public GameObject current_gameobject;
    private saturationScript saturation;

    // Use this for initialization
    void Start () {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        saturation = mainCamera.GetComponent<saturationScript>();
	}
	
	void FixedUpdate () {
        //Hovering
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

        if (saturation!=null)
        {
            saturation.isSaturationOn = true;
        }

        RaycastHit hit;
        
        if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, distance))
        {
            //Debug.DrawLine(rayOrigin, hit.transform.position, Color.green);
			var interactableObject = hit.transform.gameObject.GetComponent<Clickable>();
            if (interactableObject != null)
            {
                interactableObject.Hover();
            }
            current_gameobject = hit.transform.gameObject;
            old_gameobject = current_gameobject;

            if (saturation != null)
            {
                saturation.isSaturationOn = false;
            }
        }

        if (hit.transform == null) { current_gameobject = null; }

        if (old_gameobject != current_gameobject && old_gameobject != null)
        {
			var interactableObject = old_gameobject.GetComponent<Clickable>();
            if (interactableObject != null){
                interactableObject.NoHover();
            }
        }

        //Interacting
        //Input.GetKeyDown("Fire1")
        if (Input.GetMouseButtonDown(0) && current_gameobject != null){
			var interactableObject = current_gameobject.GetComponent<Clickable>();
            if (interactableObject != null){
                interactableObject.Interact();
            }
            
        }

        
    }
}
