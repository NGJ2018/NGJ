using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public Camera mainCamera;
    public float distance;
    private saturationScript saturation;
    public Clickable old_gameobject_click;
    public Clickable current_gameobject_click;

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
			var interactableObject = hit.transform.gameObject.GetComponent<Clickable>();
            if (interactableObject != null){
                interactableObject.Hover();
            }
            if (saturation != null)
            {
                saturation.isSaturationOn = false;
            }
        }

        if (hit.transform == null) { current_gameobject = null; }
            current_gameobject_click = hit.transform.gameObject.GetComponent<Clickable>();
            
            if(old_gameobject_click != current_gameobject_click){
                if(old_gameobject_click != null) { old_gameobject_click.NoHover(); }
                old_gameobject_click = current_gameobject_click;
            }
        }

        if (hit.transform == null) { current_gameobject_click = null; }
        
        //Interacting
        //Input.GetKeyDown("Fire1")
        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")) && current_gameobject_click != null){
          var interactableObject = current_gameobject_click;
            if (interactableObject != null){
                interactableObject.Interact();
            }
            
        }
        
    }

    private bool checkIfObjectsHaveChanged(){
        if (old_gameobject_click != current_gameobject_click && old_gameobject_click != null)
        {
            var interactableObject = old_gameobject_click;
            if (interactableObject != null)
            {
                interactableObject.NoHover();
            }
            return true;
        }
        else { return false; }
    }
}
