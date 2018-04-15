using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class BlinkController : MonoBehaviour {

	public delegate void BlinkDelegate();
	public static event BlinkDelegate OnBlink;
	public static event BlinkDelegate OnBlinkEnd;
    public Image crosshair;

	private Animator anim;

	private Material blinkMat;

	public bool IsBlinking = false;

	public static BlinkController Singleton;

	[Range(0,1)]
	public float Progress;


	public void Start(){
		blinkMat = new Material(Shader.Find("Custom/BlinkShader"));

		anim = GetComponent<Animator> ();

		OnBlink += RandomBlinkStuff;
		OnBlinkEnd += RandomBLinkStuffEnd;

		//StartCoroutine (ConstantBlink ());

		Singleton = this;
        crosshair = GameObject.Find("CrossHair").GetComponent<Image>();
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dst){
		blinkMat.SetFloat ("_Progress", Progress);
		Graphics.Blit (src, dst, blinkMat);
	}

	public void RandomBlinkStuff(){
		IsBlinking = true;
    }

	public void RandomBLinkStuffEnd(){
		IsBlinking = false;
	}

	public void InitiateBlink(){
		anim.SetTrigger ("Blink");
	}

	/*
	public void OnGUI(){
		if (GUI.Button (new Rect(new Vector2(100,100), new Vector2(100,20)), "BLINK")) {
			InitiateBlink ();
		}
	}
	*/
	public void StartBlink (){
		if (OnBlink != null) {
			OnBlink ();
            crosshair.enabled = false;
        }
	}

	public void StopBlink(){
		if (OnBlinkEnd != null) {
			OnBlinkEnd();
            crosshair.enabled = true;
        }
	}

	public IEnumerator BlackEffectRoutine(){
		yield return new WaitForEndOfFrame ();
	}

	public IEnumerator ConstantBlink(){
		while (true) {
			yield return new WaitForSeconds (Random.Range (6,8));
			InitiateBlink ();
		}
	}

}
