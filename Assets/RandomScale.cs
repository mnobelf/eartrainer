using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource[] audioSources;
    int root;
    int scale;
    int index;

    void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        root = Random.Range(0,12);
        scale = Random.Range(1, 5);

        if (scale == 1)
        {
            Invoke("PlayMajor", 1f);
        }
        else if (scale == 2)
        {
            Invoke("PlayMinor", 1f);
        }
        else if (scale == 3)
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
        index = root;
        Invoke("PlayANote", 1f);
        index = root + 2;
        Invoke("PlayANote", 1f);
        index = root + 4;
        Invoke("PlayANote", 1f);
        index = root + 5;
        Invoke("PlayANote", 1f);
        index = root + 7;
        Invoke("PlayANote", 1f);
        index = root + 9;
        Invoke("PlayANote", 1f);
        index = root + 11;
        Invoke("PlayANote", 1f);
    }

    void PlayMinor()
    {
        index = root;
        Invoke("PlayANote", 1f);
        index = root + 2;
        Invoke("PlayANote", 1f);
        index = root + 3;
        Invoke("PlayANote", 1f);
        index = root + 5;
        Invoke("PlayANote", 1f);
        index = root + 7;
        Invoke("PlayANote", 1f);
        index = root + 8;
        Invoke("PlayANote", 1f);
        index = root + 10;
        Invoke("PlayANote", 1f);
    }

    void PlayPentatonicMajor()
    {
        index = root;
        Invoke("PlayANote", 1f);
        index = root + 2;
        Invoke("PlayANote", 1f);
        index = root + 4;
        Invoke("PlayANote", 1f);
        index = root + 7;
        Invoke("PlayANote", 1f);
        index = root + 9;
        Invoke("PlayANote", 1f);
    }

    void PlayBlues()
    {
        index = root;
        Invoke("PlayANote", 1f);
        index = root + 2;
        Invoke("PlayANote", 1f);
        index = root + 3;
        Invoke("PlayANote", 1f);
        index = root + 4;
        Invoke("PlayANote", 1f);
        index = root + 7;
        Invoke("PlayANote", 1f);
        index = root + 9;
        Invoke("PlayANote", 1f);
    }

    void PlayANote()
    {
        audioSources[index].Play();
    }
}

