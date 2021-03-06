﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInterval : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource[] audioSources;
    int root;
    int interval;
    public QuizManager QuizManager;
    public bool started;

    public void PlaySound()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        started = true;
        foreach (AudioSource item in audioSources)
        {
            item.Stop();
        }
        root = Random.Range(5,18);
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

        if (started) {
            audioSources = gameObject.GetComponents<AudioSource>();
            Invoke("PlaySound1", 1f);
        } else {
            PlaySound();
        }
    }

    // Update is called once per frame
    void PlaySound1()
    {
        audioSources[root].Play();
        Invoke("PlaySound2", 1f);
    }

    void PlaySound2()
    {
        audioSources[root+interval].Play();
    }
}
