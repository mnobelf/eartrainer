using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int answer;
    public RandomInterval generator;
    public RandomScale generator2;
    public RandomChord generator3;

    void AskGenerator()
    {
        if (gameObject.tag == "Scale")
        {
            generator2.PlaySound();
        } else if (gameObject.tag == "Chord")
        {
            generator3.PlaySound();
        } else
        {
            generator.PlaySound();
        }
    }

    public void SetKeyAnswer(int input)
    {
        answer = input;
    }

    public void CheckAnswer(int input)
    {
        if (input == answer) {
            Debug.Log("Correct");
            Invoke("AskGenerator",1f);
        } else {
            Debug.Log("Incorrect");
        }
    }

    void Start()
    {
        Invoke("AskGenerator",1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
