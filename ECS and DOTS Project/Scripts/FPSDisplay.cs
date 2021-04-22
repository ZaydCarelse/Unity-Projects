using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public float timer, refresh, avgFrameRate;
    public string display = "{0} FPS";
    public Text fpsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFrameRate = (int)(1f / timelapse);
        fpsText.text = string.Format(display, avgFrameRate.ToString());
    }
}
