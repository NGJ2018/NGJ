using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIspriteAnimator : MonoBehaviour {

    Image localImage;
    public Sprite[] spriteArray;
    public float cycleSpeed = 0.1f;


    // Use this for initialization
    void OnEnable()
    {
        localImage = this.GetComponent<Image>();
        StartCoroutine(cycleSprites());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator cycleSprites()
    {
        int i = 0;

        while (true)
        {
            localImage.sprite = spriteArray[++i % spriteArray.Length];
            yield return new WaitForSeconds(cycleSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}
