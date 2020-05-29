using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
	
	public GameObject Cube;
	public GameObject L;
	
    void Update()
    {
		
		if(Input.GetKeyUp("1")) // Set Cube to be the active object when "1" is pressed.
		{
			Cube.SetActive(true);
			L.SetActive(false);
		}
		else if(Input.GetKeyUp("2")) // Set Cube to be the active object when "1" is pressed.
		{
			Cube.SetActive(false);
			L.SetActive(true);
		}
    }
}
