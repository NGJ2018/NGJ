using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteCycler : MonoBehaviour {

    SpriteRenderer thisRenderer;
    public Sprite[] spriteArray;
    public float cycleSpeed = 0.1f;

	// Use this for initialization
	void Awake () {
        thisRenderer = this.GetComponent<SpriteRenderer>();
        StartCoroutine(cycleSprites());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator cycleSprites()
    {
        Debug.Log("CoroutineStarted");

        int i = 0;

        while (true) {
            thisRenderer.sprite = spriteArray[++i%spriteArray.Length];
            yield return new WaitForSeconds(cycleSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}
