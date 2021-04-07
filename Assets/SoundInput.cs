using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInput : MonoBehaviour
{
    public AudioSource audioSource;
    public int audioSampleRate = 44100;
    public string microphone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnClick()
    {
        Debug.Log("terpencet");
        foreach (string device in Microphone.devices)
        {
            if (microphone == null)
            {
                microphone = device;
            }
            //options.Add(device);
        }
        audioSource.Stop();
        audioSource.clip = Microphone.Start(microphone, false, 10, audioSampleRate);
        audioSource.loop = false;
        Debug.Log(Microphone.IsRecording(microphone).ToString());

        if (Microphone.IsRecording(microphone))
        { 
            while (!(Microphone.GetPosition(microphone) > 0))
            {
            } 

            Debug.Log("recording started with " + microphone);

        }
        else
        {

            Debug.Log(microphone + " doesn't work!");
        }

    }
}
