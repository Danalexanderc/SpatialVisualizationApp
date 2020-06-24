using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotationScreenChallengeManager : MonoBehaviour
{
	public Sprite[] sprites;
	
	public GameObject s;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
		
        
    }

    // Update is called once per frame
    void Update()
    {
     
		if(Input.GetKeyUp("g"))
			s.GetComponent<SpriteRenderer>().sprite = sprites[1];
		if(Input.GetKeyUp("h"))
			s.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }
}
