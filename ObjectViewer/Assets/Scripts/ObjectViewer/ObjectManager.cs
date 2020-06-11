using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
	public GameObject[] objects;
	public int active = 4;
	
	private string[] keys = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
	
    void Update()
    {
		for(int i = 0; i < objects.Length; i++){
			if(Input.GetKeyUp(keys[i])){
				objects[active].SetActive(false);
				active = i;
				objects[active].SetActive(true);
			}
		}
    }
}
