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
    public QuizManager QuizManager;

    void Start()
    {
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
    }

    public void PlaySound()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        foreach (AudioSource item in audioSources)
        {
            item.Stop();
        }
        root = Random.Range(0,12);
        scale = Random.Range(1, 5);

        if (scale == 1)
        {
            StartCoroutine(PlayMajor());
            QuizManager.SetKeyAnswer(1);
        }
        else if (scale == 2)
        {
            StartCoroutine(PlayMinor());
            QuizManager.SetKeyAnswer(2);
        }
        else if (scale == 3)
        {
            StartCoroutine(PlayPentatonicMajor());
            QuizManager.SetKeyAnswer(3);
        }
        else
        {
            StartCoroutine(PlayBlues());
            QuizManager.SetKeyAnswer(4);
        }
        
    }

    public void Repeat()
    {
        if (scale == 1)
        {
            StartCoroutine(PlayMajor());
            QuizManager.SetKeyAnswer(1);
        }
        else if (scale == 2)
        {
            StartCoroutine(PlayMinor());
            QuizManager.SetKeyAnswer(2);
        }
        else if (scale == 3)
        {
            StartCoroutine(PlayPentatonicMajor());
            QuizManager.SetKeyAnswer(3);
        }
        else
        {
            StartCoroutine(PlayBlues());
            QuizManager.SetKeyAnswer(4);
        }
        
    }
    // Update is called once per frame
    IEnumerator PlayMajor()
    {
        index = root;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 2;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 4;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 5;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 7;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 9;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 11;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 12;
        Invoke("PlayANote",0);
    }

    IEnumerator PlayMinor()
    {
        index = root;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 2;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 3;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 5;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 7;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 8;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 10;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 12;
        Invoke("PlayANote",0);
    }

    IEnumerator PlayPentatonicMajor()
    {
        index = root;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 2;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 4;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 7;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 9;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 12;
        Invoke("PlayANote",0);
    }

    IEnumerator PlayBlues()
    {
        index = root;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 2;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 3;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 4;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 7;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 9;
        Invoke("PlayANote",0);
        yield return new WaitForSeconds(1);
        Invoke("StopANote",0);
        index = root + 12;
        Invoke("PlayANote",0);
    }

    void PlayANote()
    {
        audioSources[index].Play();
    }

    void StopANote()
    {
        audioSources[index].Stop();
    }
}

