using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCPScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void btnTest()
    {
    	Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
