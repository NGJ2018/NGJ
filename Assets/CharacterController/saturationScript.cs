using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class saturationScript : MonoBehaviour
{

    PostProcessingProfile saturation;

    public bool isSaturationOn = false;
    private GrainModel.Settings grain;

    // Use this for initialization
    void Start()
    {
        saturation = GetComponent<PostProcessingBehaviour>().profile;
        grain = saturation.grain.settings;
    }

    // Update is called once per frame
    void Update()
    {
        if (saturation != null)
        {
            saturation.grain.enabled = true;
            grain = saturation.grain.settings;
            if (isSaturationOn)
            {
                if (grain.intensity<=0.29f) //Gradually increase grain intensity to 1
                {
                    grain.intensity += 0.01f;
                }
            }
            else
            {
                if (grain.intensity >= 0) //Gradually decrease grain intensity to 0
                {
                    grain.intensity -= 0.01f;
                }
            }
            saturation.grain.settings = grain; //Set grain settings in postprocessing profile to new settings
        }

    }
}
