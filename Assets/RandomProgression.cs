using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomProgression : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource[] audioSources;
    public int root;
    public int chord;
    public QuizManager QuizManager;
    int[] answer = new int[3];
    public string[] rep = new string[3];
    public Button b;

    public void PlaySound()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        chord = Random.Range(1,3);
        chord = 1;

        if (chord == 1)
        {
            StartCoroutine(PlayMajor());
        }
        else if (chord == 2)
        {
            StartCoroutine(PlayMinor());
            // QuizManager.SetKeyAnswer(2);
        }
        // else 
        // {
        //     StartCoroutine(PlayAugmented());
        // }
 
    }

    // Update is called once per frame
    IEnumerator PlayMajor()
    {
        int[] AllowedValues = new int[] {0, 2, 4, 5, 7, 9, 11};
        int root = AllowedValues[Random.Range(0,7)];

        audioSources[root].Play();
        yield return new WaitForSeconds(1.0f);

        int rand = Random.Range(1,4);

        if (rand == 1) { 
            answer[0] = 1;

            Invoke("ProgI", 0.5f);

            yield return new WaitForSeconds(1.0f);

            rand = Random.Range(1,3);

            if (rand == 1) {
                answer[1] = 2;
                answer[2] = 3;
    
                Invoke("ProgIV", 0.5f);
                
                yield return new WaitForSeconds(1.0f);

                Invoke("ProgV", 0.5f);
            }
            else {
                answer[1] = 3;
                answer[2] = 2;
                
                Invoke("ProgV", 0.5f);

                yield return new WaitForSeconds(1.0f);

                Invoke("ProgIV", 0.5f);
            }
        }
        else if (rand == 2) {
            answer[0] = 2;

            Invoke("ProgIV", 0.5f);

            yield return new WaitForSeconds(1.0f);

            rand = Random.Range(1,3);

            if (rand == 1) {
                answer[1] = 1;
                answer[2] = 3;
                
                Invoke("ProgI", 0.5f);
                
                yield return new WaitForSeconds(1.0f);

                Invoke("ProgV", 0.5f);
            }
            else {
                answer[1] = 3;
                answer[2] = 1;

                Invoke("ProgV", 0.5f);

                yield return new WaitForSeconds(1.0f);

                Invoke("ProgI", 0.5f);
            }
        }
        else if (rand == 3) {
            answer[0] = 3;

            Invoke("ProgV", 0.5f);

            yield return new WaitForSeconds(1.0f);

            rand = Random.Range(1,3);

            if (rand == 1) {
                answer[1] = 1;
                answer[2] = 2;

                Invoke("ProgI", 0.5f);
                
                yield return new WaitForSeconds(1.0f);

                Invoke("ProgIV", 0.5f);
            }
            else {
                answer[1] = 2;
                answer[2] = 1;

                Invoke("ProgIV", 0.5f);

                yield return new WaitForSeconds(1.0f);

                Invoke("ProgI", 0.5f);
            }
        }

        for (int c = 0; c < 3; c++)
        {
            if (answer[c] == 1)
                rep[c] = "ProgI";
            else if (answer [c] == 2)
                rep[c] = "ProgIV";
            else
                rep[c] = "ProgV";
        }

        QuizManager.SetKeyAnswerProg(answer);
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

    void Start()
    {
        Button button = b.GetComponent<Button>();
        button.onClick.AddListener(delegate {StartCoroutine(Replay());});
    }

    IEnumerator Replay()
    {
        Invoke(rep[0], 0.5f);
        yield return new WaitForSeconds(1.0f);

        Invoke(rep[1], 0.5f);
        yield return new WaitForSeconds(1.0f);

        Invoke(rep[2], 0.5f);
        yield return new WaitForSeconds(1.0f);
    }


}