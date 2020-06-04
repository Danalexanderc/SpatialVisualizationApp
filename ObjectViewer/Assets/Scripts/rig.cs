using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rig : MonoBehaviour
{
    public Transform t;

    public float rotX = 0f, rotY = 0f, rotZ = 0f, rotationDelta = 4, moveDelta = 0.1f;

    public Vector3 defaultScale = new Vector3();

    private Vector3 rotation = new Vector3(), scaleChange = new Vector3(), position = new Vector3(0,0,1);

	void Start(){
		defaultScale.Set(1.0f, 1.0f, 1.0f);
	}

    // Using FixedUpdate instead of Update because I am using physics
    void FixedUpdate()
    {
        
        // Rotation controls
        if (Input.GetKey("w"))
            rotX += rotationDelta;
        if (Input.GetKey("s"))
            rotX -= rotationDelta;
        if (Input.GetKey("a"))
            rotY += rotationDelta;
        if (Input.GetKey("d"))
            rotY -= rotationDelta;
        if (Input.GetKey("q"))
            rotZ += rotationDelta;
        if (Input.GetKey("e"))
            rotZ -= rotationDelta;

		/*
		// Position controls
		if (Input.GetKey("up"))
			if(Input.GetKey(KeyCode.LeftShift))
				position.y += moveDelta;
			else 
				position.z += moveDelta;
		if (Input.GetKey("down"))
            if(Input.GetKey(KeyCode.LeftShift))
				position.y -= moveDelta;
			else 
				position.z -= moveDelta;
		if (Input.GetKey("left"))
            position.x -= moveDelta;
		if (Input.GetKey("right"))
            position.x += moveDelta;
		*/

		/*
        // Scale controls
        if (Input.GetKey("q")  &&  t.localScale.x <= 1.2f)
            scaleChange.Set(0.01f, 0.01f, 0.01f);
        else if (Input.GetKey("a")  &&  t.localScale.x > 0f)
            scaleChange.Set(-0.01f, -0.01f, -0.01f);
        else
            scaleChange.Set(0f, 0f, 0f);
		*/
		
		float tiltAngle = 60.0f;
		
		float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
		
		Quaternion target = Quaternion.Euler(rotX, rotY, rotZ);

        // Dampen towards the target rotation
        t.rotation = target;
		
		if (Input.GetKey("r")) // Reset scale and rotation.
        {
			rotX = 0; rotY = 0; rotZ = 0;
            t.localScale = defaultScale;
			position = new Vector3(0,0,1);
        }

		//rotation.Set(rotX, rotY, rotZ);
        //t.eulerAngles = rotation;
		

        t.localScale += scaleChange;
        t.localPosition = position;

    }
}
