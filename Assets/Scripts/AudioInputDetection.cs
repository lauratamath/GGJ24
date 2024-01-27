using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Ref: https://www.youtube.com/watch?v=dzD0qP8viLw

public class AudioInputDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneCLip; 

    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneCLip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneCLip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPoistion = clipPosition - sampleWindow;

        if (startPoistion < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPoistion);

        // loudness of audioclip
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }
}
