using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
	public void PlayPractice1(){
		SceneManager.LoadScene("OVPractice1");
	}
	
	public void PlayPractice2(){
		SceneManager.LoadScene("OVPractice2");
	}

	public void PlayPractice3(){
		SceneManager.LoadScene("OVPractice3");
	}
}
