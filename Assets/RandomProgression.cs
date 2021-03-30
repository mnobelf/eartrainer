using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProgression : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource[] audioSources;
    int root;
    int chord;
    float interval = 1.0f;

    void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        chord = Random.Range(1,2);
        chord = 2;

        if (chord == 1)
        {
            StartCoroutine(PlayMajor());
        }
        else if (chord == 2)
        {
            StartCoroutine(PlayMinor());
        }
        // else 
        // {
        //     StartCoroutine(PlayAugmented());
        // }
 
    }

    // Update is called once per frame
    IEnumerator PlayMajor()
    {
        int rand = Random.Range(1,3);

        int[] AllowedValues = new int[] {0, 2, 4, 5, 7, 9, 11};
        int root = AllowedValues[Random.Range(0,6)];

        // // Invoke("C", 0.5f);

        audioSources[root].Play();
        yield return new WaitForSeconds(1.0f);

        if (rand == 1) { 

            Invoke("ProgI", 0.5f);

            yield return new WaitForSeconds(1.0f);

            rand = Random.Range(1,2);

            if (rand == 1) {
                Invoke("ProgIV", 0.5f);
                
                yield return new WaitForSeconds(1.0f);

                Invoke("ProgV", 0.5f);
            }
            else {
                Invoke("ProgIV", 0.5f);

                yield return new WaitForSeconds(1.0f);

                Invoke("ProgV", 0.5f);
            }
        }
        else if (rand == 2) {
           Invoke("ProgIV", 0.5f);

            yield return new WaitForSeconds(1.0f);

            rand = Random.Range(1,2);

            if (rand == 1) {
                Invoke("ProgI", 0.5f);
                
                yield return new WaitForSeconds(1.0f);

                Invoke("ProgV", 0.5f);
            }
            else {
                Invoke("ProgV", 0.5f);

                yield return new WaitForSeconds(1.0f);

                Invoke("ProgI", 0.5f);
            }
        }
        else {
            Invoke("ProgV", 0.5f);

            yield return new WaitForSeconds(1.0f);

            rand = Random.Range(1,2);

            if (rand == 1) {
                Invoke("ProgI", 0.5f);
                
                yield return new WaitForSeconds(1.0f);

                Invoke("ProgIV", 0.5f);
            }
            else {
                Invoke("ProgIV", 0.5f);

                yield return new WaitForSeconds(1.0f);

                Invoke("ProgI", 0.5f);
            }
        }
    }

    IEnumerator PlayMinor()
    {
        Invoke("Progii", 0.5f);
        yield return new WaitForSeconds(1.0f);
    }

    void ProgI()
    {
        audioSources[root].Play();
        audioSources[root+4].Play();
        audioSources[root+7].Play();
    }

    void ProgIV()
    {
        audioSources[root+5].Play();
        audioSources[root+9].Play();
        audioSources[root+12].Play();        
    }

    void ProgV()
    {
        audioSources[root+7].Play();
        audioSources[root+11].Play();
        audioSources[root+14].Play();        
    }

    void Progii()
    {
        audioSources[0].Play();
        audioSources[3].Play();
        audioSources[7].Play();
    }


}