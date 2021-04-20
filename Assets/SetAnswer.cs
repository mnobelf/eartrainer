using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class SetAnswer : MonoBehaviour
{
    public int Answer;
    public int i = 0;
    public QuizManager QuizManager;
    public Button b1, b2, b3;

    public void SendAnswer()
    {
        QuizManager.CheckAnswer(Answer);
    }

    public void SendAnswerProg()
    {

        QuizManager.CheckAnswerProg(Answer);


    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
