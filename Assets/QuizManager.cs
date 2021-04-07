using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int answer;
    public int[] ans = new int[3];
    public RandomInterval generator;
    public RandomScale generator2;
    public RandomChord generator3;
    public RandomProgression generator4;
    public CheckCorrectness correctness;

    void AskGenerator()
    {
        if (gameObject.tag == "Scale")
        {
            generator2.PlaySound();
        }
        else if (gameObject.tag == "Chord")
        {
            generator3.PlaySound();
        }
        else if (gameObject.tag == "Progression")
        {
            generator4.PlaySound();
        }
        else
        {
            generator.PlaySound();
        }
    }

    public void SetKeyAnswer(int input)
    {
        answer = input;
    } 

    public void SetKeyAnswerProg(int[] input)
    {
        ans[0] = input[0];
        ans[1] = input[1];
        ans[2] = input[2];
    } 

    public void CheckAnswer(int input)
    {
        if (input == answer) {
            Debug.Log("Correct");
            correctness.correct();
            Invoke("AskGenerator",1f);
        } else {
            Debug.Log("Incorrect");
            correctness.incorrect();
        }
    }

    public void CheckAnswerProg(int[] input)
    {
        if ((input[0] == ans[0]) && (input[1] == ans[1]) && (input[2] == ans[2])) {
            correctness.correct();
            Invoke("AskGenerator",2f);
        } else {
            correctness.incorrect();
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
