using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateInterval : MonoBehaviour
{

    public float pi_mic;

    int index_interval;
    int index_up_down;
    int index_not;
    int index_not_answer;
    int chord;
    int pitchAnswer;
    string[] interval_name;
    string[] not_name;
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

        index_interval = Random.Range(0, 12);
        interval_name = new string[12];
        interval_name[0] = "Minor 2nd";
        interval_name[1] = "Major 2nd";
        interval_name[2] = "Minor 3rd";
        interval_name[3] = "Major 3rd";
        interval_name[4] = "Perfect 4th";
        interval_name[5] = "Tritone";
        interval_name[6] = "Perfect 5th";
        interval_name[7] = "Minor 6th";
        interval_name[8] = "Major 6th";
        interval_name[9] = "Minor 7th";
        interval_name[10] = "Major 7th";
        interval_name[11] = "Octave";

        index_up_down = Random.Range(0, 2);
        //index_up_down = 1;
        if (index_up_down == 0)
        {
            txt.text = interval_name[index_interval] + " Up";
        }
        else
        {
            txt.text = interval_name[index_interval] + " Down";
        }

        index_not = Random.Range(0, 11);
        aus[index_not].Play();
        Debug.Log(index_interval.ToString());
        Debug.Log(aus[index_not].name);

        index_not_answer = index_not + (index_interval + 1);
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

        if (index_up_down == 0)
        {
            pitchAnswer = pitchNot[aus[index_not].name] + (index_interval + 1);
        }
        else
        {
            pitchAnswer = pitchNot[aus[index_not].name] - (index_interval + 1);
        }
        Debug.Log(pitchAnswer.ToString());

    }

    public void HearAgain()
    {
        aus[index_not].Play();
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
