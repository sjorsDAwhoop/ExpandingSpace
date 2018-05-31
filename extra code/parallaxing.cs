using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxing : MonoBehaviour {
	
	public Transform [] backgrounds;
	private float[] parallaxScales;

	
	public Vector3 previousCameraPosition;
	

	// Use this for initialization
	void Start () {
		
		previousCameraPosition = transform.position;
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < parallaxScales.Length; i++)
		{
			parallaxScales[i] = -backgrounds[i].localPosition.z;
			
		}
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		


		for (int i = 0; i < backgrounds.Length; i++)
		{
			
			Vector3 parallax = (previousCameraPosition - transform.position) * parallaxScales[i];

			backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);
		}
		
		previousCameraPosition = transform.position;
		
	}
}
