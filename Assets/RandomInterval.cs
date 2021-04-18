using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInterval : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource[] audioSources;
    int root;
    int interval;
    public QuizManager QuizManager;

    public void PlaySound()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        root = Random.Range(0,24);
        interval = Random.Range(0, 2);
        if (interval == 1) 
        {
            interval = Random.Range(1, 6);
        } else 
        {
            interval = Random.Range(-5, 0);
        }
        QuizManager.SetKeyAnswer(interval);

        Invoke("PlaySound1", 1f);
    }

    public void Repeat()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        Invoke("PlaySound1", 1f);
    }

    // Update is called once per frame
    void PlaySound1()
    {
        audioSources[root].Play();
        Invoke("PlaySound2", 1f);
    }

    void PlaySound2()
    {
        if (root + interval < 23 && root + interval > -1) 
        {
            audioSources[root+interval].Play();
        }
        else 
        {
            audioSources[root+3].Play();
        }
    }
}
