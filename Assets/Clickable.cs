using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour {

    public Material basic_material;
    public Material basic_material_with_outline;

    public abstract void Interact();

    public void Hover(){
        this.gameObject.GetComponent<Renderer>().material = basic_material_with_outline;
    }

    public void NoHover(){
        //var mat = this.gameObject.GetComponent<Material>();
        //mat = basic_material_with_outline;
        this.gameObject.GetComponent<Renderer>().material = basic_material;
    }

}
