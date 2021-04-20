using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateP5 : MonoBehaviour
{

    public float pi_mic;

    int chord;
    int index_not;
    int pitchAnswer;
    public Text txt;
    public AudioSource[] audioSources;
    public AudioSource mic;
    public PitchAnalyzer analyzer;
    
    // Start is called before the first frame update
    void Start()
    {
        Play();
    }

    void Play()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        chord = Random.Range(0, 1);

        //index_up_down = 1;
        if (chord == 0)
        {
            txt.text = "Major";
        }
        else
        {
            txt.text = "Minor";
        }

        index_not = Random.Range(3, 15);
        audioSources[index_not].Play();
        audioSources[index_not+7].Play();
        //Debug.Log(index_not_answer.ToString());

        if (chord == 0)
        {
            pitchAnswer = index_not + 28 + 4;
        }
        else
        {
            pitchAnswer = index_not + 28 + 3;
        }
        Debug.Log(pitchAnswer.ToString());

    }

    public void HearAgain()
    {
        audioSources[index_not].Play();
        audioSources[index_not+7].Play();
    }

    // Update is called once per frame
    void Update()
    {
        pi_mic = analyzer.AnalyzeSound(mic);
        if ((pi_mic>=(pitchAnswer-0.3)) && ((pi_mic <= (pitchAnswer + 0.3))))
        {
            txt.text = "Answer Correct";
            pitchAnswer = 88;
            Invoke("Play", 2f);
        }
    }

}
