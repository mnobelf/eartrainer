using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnswer : MonoBehaviour
{
    public int Answer;
    public QuizManager QuizManager;

    public void SendAnswer()
    {
        QuizManager.CheckAnswer(Answer);
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
