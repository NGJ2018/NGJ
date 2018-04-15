using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ButtonSpriteAnimator : MonoBehaviour {

    public CanvasGroup Blink;
    Button localButton;
    public Sprite[] spriteArray;
    public float cycleSpeed = 0.1f;
    float time = 0.5f;
    MouseLook mouseLook;

    // Use this for initialization
    void OnEnable()
    {
        localButton = this.GetComponent<Button>();
        StartCoroutine(cycleSprites());
        BlinkController.OnBlinkEnd += StartFadingOut;
        mouseLook = GameObject.Find("Player 1").GetComponent<RigidbodyFirstPersonController>().mouseLook;
    }

    IEnumerator cycleSprites()
    {
        int i = 0;

        while (true)
        {
            localButton.image.sprite = spriteArray[++i % spriteArray.Length];
            yield return new WaitForSeconds(cycleSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    public void StartBlink()
    {
		BlinkController.OnBlinkEnd += PsychologyManager.Singleton.BeginPsychInteraction;
		GameController.Singleton.ProgressStoryline (0);
    }

    public void StartFadingOut()
    {
        StartCoroutine(FadeOut());
        BlinkController.OnBlinkEnd -= StartFadingOut;
    }

    IEnumerator FadeOut()
    {
        mouseLook.lockCursor = true;
        Blink.interactable = false;
        while (Blink.alpha > 0)
        {
            Blink.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

}
