using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectionTexture : MonoBehaviour
{
	
    public RenderTexture cameraTexture;
	public Color c = new Color(0,1,1);
	public Texture2D texture;
	
	public Camera cam;
	
	public int resWidth = 480; 
    public int resHeight = 270;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		
        if (Input.GetKeyDown("s"))
		{	
			RenderTexture temp = RenderTexture.active;
			
			RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            cam.targetTexture = rt;
            cam.Render();
            RenderTexture.active = rt;
            texture.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
			texture.Apply();
            cam.targetTexture = null;
			
            RenderTexture.active = temp;
            Destroy(rt);
		}
		
		
		
    }
	

}
