using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour {

    public Material basic_material;
    public Material basic_material_with_outline;
    public bool playAudio;

    public abstract void Interact();

    public void Hover(){
        if(basic_material == null){
            //FIND MATERIAL
        }
        var render = this.gameObject.GetComponent<Renderer>();
        if(render != null){
            render.material = basic_material_with_outline;
            var spriteGlow = this.GetComponent<SpriteGlowEffect>();
            if (spriteGlow != null && playAudio){
                //counter++;
                //spriteGlow.enabled = true;
                
                if (spriteGlow.OutlineWidth <= 10.0 
                    //&& counter%10==0
                    ){
                    spriteGlow.enabled = true;
                    spriteGlow.OutlineWidth += 0.2f;
                    spriteGlow.AlphaThreshold = 0.05f;
                }else { spriteGlow.OutlineWidth = 10.0f; }
                
            }
        }
    }

    public void NoHover(){
        var render = this.gameObject.GetComponent<Renderer>();
        if (render != null){
            render.material = basic_material;
            var spriteGlow = this.GetComponent<SpriteGlowEffect>();
            if(spriteGlow != null){
                //spriteGlow.enabled = false;
                spriteGlow.OutlineWidth = 0;
                spriteGlow.AlphaThreshold = 0.0f;
            }
            else { Debug.Log("spriteGlowEffect is null"); }

        }
    }
	/*
	public void OnGUI(){
		if (GUI.Button (new Rect (new Vector2 (100, 100), new Vector2 (100, 20)), "interact")) {
			Interact ();
		}
	}*/
}
