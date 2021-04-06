using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class contohhh : MonoBehaviour
{
	public int i = 0;
	public Button b1, b2, b3;
	public int[] ans = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = b1.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick);

		Button btn2 = b2.GetComponent<Button>();
		btn2.onClick.AddListener(TaskOnClick);

		Button btn3 = b3.GetComponent<Button>();
		btn3.onClick.AddListener(TaskOnClick);

		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick(){
    	ans[i] = i;
		Debug.Log ("You have clicked the button! I = " + i);
		i++;
	}
}
