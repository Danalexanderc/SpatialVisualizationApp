using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectViewerRig : MonoBehaviour
{
    public Transform t;
    public float rotationDelta = 3, movementDelta = 0.1f;
	public Vector3 defaultPosition = new Vector3(0, 0, 1);
	
	public bool translation = false;

    private Vector3 position = new Vector3();
	
	 private Vector3 target = new Vector3(5.0f, 0.0f, 0.0f);
	
	void Start(){
		reset();
	}

    void FixedUpdate()
    {		
		
	    // Rotation controls	
		if(!Input.GetKey(KeyCode.Space)){
			if (Input.GetKey("w"))
				t.Rotate(rotationDelta, 0, 0, Space.World);
			else if (Input.GetKey("s"))
				t.Rotate(-rotationDelta, 0, 0, Space.World);
			if (Input.GetKey("a"))
				t.Rotate(0, rotationDelta, 0, Space.World);
			else if (Input.GetKey("d"))
				t.Rotate(0, -rotationDelta, 0, Space.World);
			if (Input.GetKey("q"))
				t.Rotate(0, 0, rotationDelta, Space.World);
			else if (Input.GetKey("e"))
				t.Rotate(0, 0, -rotationDelta, Space.World);
		}
		
		
		// Movement controls
		if(translation){
			if(Input.GetKey(KeyCode.UpArrow)){
				if(Input.GetKey(KeyCode.Space))
					position.y += movementDelta;
				else 
					position.z += movementDelta;
			}
			else if(Input.GetKey(KeyCode.DownArrow)){
				if(Input.GetKey(KeyCode.Space))
					position.y -= movementDelta;
				else 
					position.z -= movementDelta;
			}
			if(Input.GetKey(KeyCode.LeftArrow))
				position.x -= movementDelta;
			if(Input.GetKey(KeyCode.RightArrow))
				position.x += movementDelta;
		}
		
		t.localPosition = position;
    }
	
	void Update(){
		if(Input.GetKeyUp("l"))
			Debug.Log(t.rotation.ToString());
		
		if(Input.GetKey(KeyCode.Space)){
			if (Input.GetKeyUp("w"))
				t.Rotate(90, 0, 0, Space.World);
			else if (Input.GetKeyUp("s"))
				t.Rotate(-90, 0, 0, Space.World);
			if (Input.GetKeyUp("a"))
				t.Rotate(0, 90, 0, Space.World);
			else if (Input.GetKeyUp("d"))
				t.Rotate(0, -90, 0, Space.World);
			if (Input.GetKeyUp("q"))
				t.Rotate(0, 0, 90, Space.World);
			else if (Input.GetKeyUp("e"))
				t.Rotate(0, 0, -90, Space.World);
		}
		
		if (Input.GetKeyUp("r")) // Reset
			reset();
	}
	
	private void reset()
	{
		t.eulerAngles = new Vector3(0, 0, 0);
		position.Set(defaultPosition.x, defaultPosition.y, defaultPosition.z);
	}
}
