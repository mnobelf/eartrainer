using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChord : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource[] audioSources;
    int root;
    int chord;

    void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        root = Random.Range(0,18);
        chord = Random.Range(1, 5);

        if (chord == 1)
        {
            Invoke("PlayMajor", 1f);
        }
        else if (chord == 2)
        {
            Invoke("PlayMinor", 1f);
        }
        else if (chord == 3)
        {
            Invoke("PlayDiminished", 1f);
        }
        else
        {
            Invoke("PlayAugmented", 1f);
        }
        
    }

    // Update is called once per frame
    void PlayMajor()
    {
        audioSources[root].Play();
        audioSources[root+4].Play();
        audioSources[root+7].Play();
    }

    void PlayMinor()
    {
        audioSources[root].Play();
        audioSources[root+3].Play();
        audioSources[root+7].Play();
    }

    void PlayAugmented()
    {
        audioSources[root].Play();
        audioSources[root+3].Play();
        audioSources[root+6].Play();
    }
}
