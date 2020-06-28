using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineForHiddenLines : MonoBehaviour
{
	public Camera solidLinesCamera;
    public RenderTexture solidLinesRender;
	public Texture2D solidLines;
	
	private int delay = 0, updateFrequency = 5;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("u")){
			
			int w = solidLinesCamera.targetTexture.width, h = solidLinesCamera.targetTexture.height;
			
			solidLinesCamera.Render();
			//Texture2D image = new Texture2D(w, h, TextureFormat.RGBA32, false);
			
			Graphics.CopyTexture(solidLinesRender, solidLines);
			
			//Graphics.CopyTexture(solidLinesRender, image);
			
			/*
			Debug.Log(w);
			Debug.Log(h);
			
			Color c = image.GetPixel(0, 0);
			int k = 0;
			
			for(int x = 0; x < w; x++){
				for(int y = 0; y < h; y++){
					Color t = image.GetPixel(x, y);
					
					solidLines.SetPixel(x, y, t);
					
					if(t == c)
						k++;
					//solidLines.SetPixel(x, y, Color.red);
				}
			}
			
			solidLines.Apply();
			Debug.Log(k);
			*/
		}
			
    }
}

