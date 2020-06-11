using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectViewerRig : MonoBehaviour
{
    public Transform t;

    public float rotationDelta = 3;

	public Vector3 defaultPosition = new Vector3(0, 0, 1);

    private Vector3 rotation = new Vector3(), position = new Vector3();
	
	void Start(){
		reset();
	}

    void FixedUpdate()
    {
	    // Rotation controls	
		if(!Input.GetKey(KeyCode.Space)){
		if (Input.GetKey("w"))
			rotation.x += rotationDelta;
		if (Input.GetKey("s"))
			rotation.x -= rotationDelta;
		if (Input.GetKey("a"))
			rotation.y += rotationDelta;
		if (Input.GetKey("d"))
			rotation.y -= rotationDelta;
		if (Input.GetKey("q"))
			rotation.z += rotationDelta;
		if (Input.GetKey("e"))
			rotation.z -= rotationDelta;
		}
			
        t.eulerAngles = rotation;
		t.localPosition = position;
    }
	
	void Update(){
		if(Input.GetKeyUp("l"))
			Debug.Log(t.rotation.ToString());
		
		
		if(Input.GetKey(KeyCode.Space)){
		if (Input.GetKeyUp("w"))
			rotation.x += 90f;
		else if (Input.GetKeyUp("s"))
			rotation.x -= 90f;
		else if (Input.GetKeyUp("a"))
			rotation.y += 90f;
		else if (Input.GetKeyUp("d"))
			rotation.y -= 90f;
		else if (Input.GetKeyUp("q"))
			rotation.z += 90f;
		else if (Input.GetKeyUp("e"))
			rotation.z -= 90f;
		}
		
		if (Input.GetKeyUp("r")) // Reset
			reset();
	}
	
	private void reset()
	{
		rotation.Set(0,0,0);
		position.Set(defaultPosition.x, defaultPosition.y, defaultPosition.z);
	}
}
