using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationText : MonoBehaviour
{
	public GameObject explanationText; // Put the explanation text to be controlled here.
	
    void Update()
    {
		
		
		if(explanationText.activeSelf){
			if(Input.anyKey)
				explanationText.SetActive(false);
		}
        else
			if(Input.GetKeyUp(KeyCode.Backslash))
				explanationText.SetActive(true);
    }
}
