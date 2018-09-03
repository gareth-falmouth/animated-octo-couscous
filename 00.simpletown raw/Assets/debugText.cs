using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Find("bg").GetComponent<UnityEngine.UI.Text>().text = Text;
        transform.Find("text").GetComponent<UnityEngine.UI.Text>().text = Text;
    }

    public String Text;
}
