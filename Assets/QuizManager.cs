using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int answer;
    public int[] keyans = new int[3];
    public int[] ans = new int[3];
    public int i = 0;
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
        keyans[0] = input[0];
        keyans[1] = input[1];
        keyans[2] = input[2];
    } 

    public void CheckAnswer(int input)
    {
        if (input == Mathf.Abs(answer)) {
            Debug.Log("Correct");
            correctness.correct();
            Invoke("AskGenerator",1f);
        } else {
            Debug.Log("Incorrect");
            correctness.incorrect();
        }
    }

    public void CheckAnswerProg(int input)
    {
        ans[i] = input;
        i++;
        
        if (i > 2) {
            i = 0;
            if ((ans[0] == keyans[0]) && (ans[1] == keyans[1]) && (ans[2] == keyans[2])) {
                correctness.correct();
                Invoke("AskGenerator",2f);
                Debug.Log("heyy");
            } else {
                correctness.incorrect();
            }
            for (int y = 0; y < 3; y++)
            {
                ans[y] = 0;
            }
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
