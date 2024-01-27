using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudio : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioInputDetection detector;

    public float loudnessSensibility = 100;
    public float threshould = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility; //change the transform

        if (loudness < threshould)
            loudness = 0;

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
