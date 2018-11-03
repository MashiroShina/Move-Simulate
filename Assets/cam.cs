using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class cam : MonoBehaviour
{
    private Camera cams;
	// Use this for initialization
	void Start () {
	    cams = GetComponent<Camera>();
	    cams.depthTextureMode = DepthTextureMode.Depth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
