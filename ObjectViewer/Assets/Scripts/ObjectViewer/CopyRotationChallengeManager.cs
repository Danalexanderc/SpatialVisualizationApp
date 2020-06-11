using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyRotationChallengeManager : MonoBehaviour
{
	public Sprite[] sprites;
	public GameObject[] progressBar;
	public Sprite progressCircleFinished;
	public GameObject completedText, imageToMatchObject, tryAnother, pressEnter;
	public Transform controlledObject;
	
	private const int numberOfChallenges = 8;
	
	private int progress = 0;
	
	private Quaternion[] rotationToMatch = new Quaternion[numberOfChallenges];
	
	private Image imageToMatch;
	
	void Start(){
		imageToMatch = imageToMatchObject.GetComponent<Image>();
		
		// Set the values of the quaternions so that they match the premade images stored in 'sprites'.
		rotationToMatch[0].Set(-0.7f, 0.3f, 0.3f, 0.7f);
		rotationToMatch[1].Set(0.0f, 0.7f, 0.7f, 0.0f);
		rotationToMatch[2].Set(0.7f, 0.0f, 0.7f, 0.0f);
		rotationToMatch[3].Set(0.1f, 0.8f, 0.4f, 0.3f);
		rotationToMatch[4].Set(0.8f, 0.0f, 0.0f, 0.6f);
		rotationToMatch[5].Set(0.0f, 0.8f, 0.6f, 0.0f);
		rotationToMatch[6].Set(0.5f, 0.5f, 0.5f, 0.5f);
		rotationToMatch[7].Set(0.7f, 0.0f, 0.7f, 0.0f);
	}

    void Update()
    {
		if(Input.GetKeyUp("i"))
			Debug.Log(CompareQuaternions(controlledObject.rotation, rotationToMatch[progress], 0.1f));
		
		if(Input.anyKey)
			tryAnother.SetActive(false);
			
		if(Input.GetKeyUp(KeyCode.Return))
			if(CompareQuaternions(controlledObject.rotation, rotationToMatch[progress], 0.1f)){ // If the object is approximately aligned to the target rotation for this challenge.
		
				if(progress < numberOfChallenges)
				{
					progressBar[progress++].GetComponent<Image>().sprite = progressCircleFinished; // Set the next progress dot to the finished sprite.
					
					if(progress == numberOfChallenges){ // If the user has finished all the challenges, display the ending message.
						completedText.SetActive(true);
						imageToMatchObject.SetActive(false);
						pressEnter.SetActive(false);
					}
					else
						imageToMatch.sprite = sprites[progress]; // Display the next image.
				}
			}
			else
				tryAnother.SetActive(true); // Set the "try another rotation!" text to visible if the user enters an incorrect rotation.
		
    }
	
	bool CompareQuaternions(Quaternion a, Quaternion b, float range) // Returns true if all the components of a are within "range" of b.
	{
		return (Mathf.Abs(a.x) <= Mathf.Abs(b.x) + range) && (Mathf.Abs(a.x) >= Mathf.Abs(b.x) - range) &&
				(Mathf.Abs(a.y) <= Mathf.Abs(b.y) + range) && (Mathf.Abs(a.y) >= Mathf.Abs(b.y) - range) &&
				(Mathf.Abs(a.z) <= Mathf.Abs(b.z) + range) && (Mathf.Abs(a.z) >= Mathf.Abs(b.z) - range) &&
				(Mathf.Abs(a.w) <= Mathf.Abs(b.w) + range) && (Mathf.Abs(a.w) >= Mathf.Abs(b.w) - range);
	}
}
