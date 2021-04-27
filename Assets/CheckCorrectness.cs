using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCorrectness : MonoBehaviour
{
	public Text answer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void correct()
    {
    	answer.text = "Correct!";
    }

    public void incorrect()
    {
    	answer.text = "Incorrect!";
    }

    public void question()
    {
        answer.text = "?";
    }
}
