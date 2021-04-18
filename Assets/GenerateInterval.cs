using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateInterval : MonoBehaviour
{

    public float pi_mic;

    int index_interval;
    int index_not;
    int index_not_answer;
    int chord;
    int pitchAnswer;
    string[] interval_name;
    string[] not_name;
    public QuizManager QuizManager;
    public Text txt;
    public AudioSource[] aus;
    public PitchAnalyzer analyzer;
    
    // Start is called before the first frame update
    void Start()
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

        txt.text = interval_name[index_interval]+" Up";


        index_not = Random.Range(0, 25);
        aus[index_not].Play();
        Debug.Log(index_interval.ToString());
        Debug.Log(aus[index_not].name);

        index_not_answer = index_not + (index_interval + 1);
        //Debug.Log(index_not_answer.ToString());

        Dictionary<string, int> pitchNot = new Dictionary<string, int>();
        pitchNot.Add("a5#", 61);
        pitchNot.Add("a5", 61);
        pitchNot.Add("a6#", 73);
        pitchNot.Add("a6", 73);
        pitchNot.Add("b5", 63);
        pitchNot.Add("b6", 75);
        pitchNot.Add("c5#", 52);
        pitchNot.Add("c5", 52);
        pitchNot.Add("c6#", 64);
        pitchNot.Add("c6", 64);
        pitchNot.Add("c7", 76);
        pitchNot.Add("d5#", 54);
        pitchNot.Add("d6#", 66);
        pitchNot.Add("e5", 56);
        pitchNot.Add("e6", 68);
        pitchNot.Add("f5#", 57);
        pitchNot.Add("f5", 57);
        pitchNot.Add("f6#", 69);
        pitchNot.Add("f6", 69);
        pitchNot.Add("g5#", 59);
        pitchNot.Add("g5", 59);
        pitchNot.Add("g6#", 71);
        pitchNot.Add("g6", 71);


        pitchAnswer = pitchNot[aus[index_not].name] + (index_interval + 1);
        Debug.Log(pitchAnswer.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        pi_mic = analyzer.AnalyzeSound(aus[25]);
        if ((pi_mic>=(pitchAnswer-1)) && ((pi_mic <= (pitchAnswer + 1))))
        {
            txt.text = "Answer Correct";
        }
    }

}
