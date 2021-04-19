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
    public AudioSource[] aus;
    public PitchAnalyzer analyzer;
    
    // Start is called before the first frame update
    void Start()
    {
        Play();
    }

    void Play()
    {

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

        index_not = Random.Range(0, 4);
        aus[index_not].Play();
        aus[index_not+7].Play();
        //Debug.Log(index_not_answer.ToString());

        Dictionary<string, int> pitchNot = new Dictionary<string, int>();
        pitchNot.Add("F#3", 34);
        pitchNot.Add("G3", 35);
        pitchNot.Add("G#3", 36);
        pitchNot.Add("A3", 37);
        pitchNot.Add("A#3", 38);
        pitchNot.Add("B3", 39);
        pitchNot.Add("C4", 40);
        pitchNot.Add("C#4", 41);
        pitchNot.Add("D4", 42);
        pitchNot.Add("D#4", 43);
        pitchNot.Add("E4", 44);

        if (chord == 0)
        {
            pitchAnswer = pitchNot[aus[index_not].name] + 4;
        }
        else
        {
            pitchAnswer = pitchNot[aus[index_not].name] - 3;
        }
        Debug.Log(pitchAnswer.ToString());

    }

    public void HearAgain()
    {
        aus[index_not].Play();
        aus[index_not+7].Play();
    }

    // Update is called once per frame
    void Update()
    {
        pi_mic = analyzer.AnalyzeSound(aus[11]);
        if ((pi_mic>=(pitchAnswer-0.3)) && ((pi_mic <= (pitchAnswer + 0.3))))
        {
            txt.text = "Answer Correct";
            pitchAnswer = 88;
            Invoke("Play", 2f);
        }
    }

}
