using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithInput : MonoBehaviour
{

    public AudioSource source;
    public float moveSpeed = 5f;
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
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshould)
            loudness = 0;

        // Move the object based on the loudness
        Vector3 moveDirection = new Vector3(loudness, 0f, 0f);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
