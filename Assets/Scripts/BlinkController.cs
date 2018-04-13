using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BlinkController : MonoBehaviour {

	public delegate void BlinkDelegate();
	public static event BlinkDelegate OnBlink;
	public static event BlinkDelegate OnBlinkEnd;

	private Animator anim;

	public static BlinkController Singleton;


	public void Start(){
		anim = GetComponent<Animator> ();

		OnBlink += RandomBlinkStuff;
		OnBlinkEnd += RandomBLinkStuffEnd;

		Singleton = this;
	}

	private void OnRengerImage(RenderTexture src, RenderTexture dst){
		Graphics.Blit (src, dst);
	}

	public static void RandomBlinkStuff(){
		print ("BlinkStart");
	}

	public static void RandomBLinkStuffEnd(){
		print ("BlinkEnd");
	}

	public void InitiateBlink(){
		anim.SetTrigger ("Blink");
	}

	private static void InitiateBlinkRender(){
		
	}

	public void OnGUI(){
		if (GUI.Button (new Rect(new Vector2(100,100), new Vector2(100,20)), "BLINK")) {
			InitiateBlink ();
		}
	}

	public void StartBlink (){
		if (OnBlink != null) {
			OnBlink ();
		}
	}

	public void StopBlink(){
		if (OnBlinkEnd != null) {
			OnBlinkEnd();
		}
	}

	public IEnumerator BlackEffectRoutine(){
		yield return new WaitForEndOfFrame ();

	}

}
