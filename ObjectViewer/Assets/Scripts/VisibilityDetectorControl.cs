using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityDetectorControl : MonoBehaviour
{
	public GameObject detector;
	public GameObject filling;
	public GameObject user;
	public float size = 0.025f;
	
	private Vector3 position = new Vector3(), scale = new Vector3();
	
    // Update is called once per frame
    void Update()
    {
		float dx = (user.transform.position.x) - (filling.transform.position.x),
			  dy = (user.transform.position.y) - (filling.transform.position.y),
			  dz = (user.transform.position.z) - (filling.transform.position.z);
		
		// Set the position of the detector to be between the user and the filling.
		position.x = ((user.transform.position.x) + (filling.transform.position.x)) / 2;
		position.y = ((user.transform.position.y) + (filling.transform.position.y)) / 2;
		position.z = ((user.transform.position.z) + (filling.transform.position.z)) / 2;
		detector.transform.position = position;
		
		scale.x = size;
		scale.y = size;
		float h = Mathf.Sqrt(dx*dx + dy*dy + dz*dz);;		
		scale.z = 0.8f * h;
		detector.transform.localScale = scale;
		
        detector.transform.LookAt(user.transform);
		
		
    }
	
	void OnTriggerEnter(Collider col)
	{
		
		if(col.gameObject.tag == "Object")
			filling.GetComponent<Renderer>().enabled = false; // Hide the filling.
	}
	
	void OnTriggerExit(Collider col)
	{
		
		if(col.gameObject.tag == "Object")
			filling.GetComponent<Renderer>().enabled = true; // Hide the filling.
	}
}
















