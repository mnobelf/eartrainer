using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class SetAnswer : MonoBehaviour
{
    public int Answer;
    public int i = 0;
    public int[] ans = new int[3];
    public QuizManager QuizManager;
    public Button b1, b2, b3;

    public void SendAnswer()
    {
        QuizManager.CheckAnswer(2);
    }

    public void SendAnswerProg(int a)
    {
    	ans[i] = a;
		i++;

		if (i > 2) 
    	{
        	QuizManager.CheckAnswerProg(ans);
    	}

    }

    // Start is called before the first frame update
    void Start()
    {
    	Button btn1 = b1.GetComponent<Button>();
		btn1.onClick.AddListener(delegate {SendAnswerProg(1);});

		Button btn2 = b2.GetComponent<Button>();
		btn2.onClick.AddListener(delegate {SendAnswerProg(2);});

		Button btn3 = b3.GetComponent<Button>();
		btn3.onClick.AddListener(delegate {SendAnswerProg(3);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
