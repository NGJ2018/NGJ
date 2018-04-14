using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour {

    public Material basic_material;
    public Material basic_material_with_outline;

    public abstract void Interact();

    public void Hover(){
        if(basic_material == null){
            //FIND MATERIAL
        }
        var render = this.gameObject.GetComponent<Renderer>();
        if(render != null){
            render.material = basic_material_with_outline;
        }
    }

    public void NoHover(){
        var render = this.gameObject.GetComponent<Renderer>();
        if (render != null){
            render.material = basic_material;
        }
    }
	public void OnGUI(){
		if (GUI.Button (new Rect (new Vector2 (100, 100), new Vector2 (100, 20)), "interact")) {
			Interact ();
		}
	}
}
