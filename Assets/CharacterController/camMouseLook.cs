using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5f;
    public float smoothing = 2f;
    GameObject character;
    PostProcessingProfile saturation;

    public bool isSaturationOn = false;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;
        saturation = GetComponent<PostProcessingBehaviour>().profile;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        if (saturation != null)
        {
            if (isSaturationOn)
            {
                saturation.motionBlur.enabled = true;
                saturation.bloom.enabled = true;
                saturation.grain.enabled = true;
            }
            else
            {
                saturation.motionBlur.enabled = false;
                saturation.bloom.enabled = false;
                saturation.grain.enabled = false;
            }
        }
    }
}
