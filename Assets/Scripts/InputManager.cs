using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.HelloAR;
using GoogleARCore.Examples.Common;

public class InputManager : MonoBehaviour {
	
	public GameObject sphereGO;
	private bool spawned = false;
	// Update is called once per frame
	void Update () {

		foreach(var t in Input.touches){

			if(t.phase != TouchPhase.Began)
				continue;

			var ray = Camera.main.ScreenPointToRay(t.position);
		//	if(Input.GetMouseButtonDown(0)){	
		//	var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hitInfo;
			if(Physics.Raycast(ray , out hitInfo) && spawned == false)
			{
				spawned = true;
				var go  = GameObject.Instantiate(sphereGO , hitInfo.point , Quaternion.identity);
				go.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
				OnTogglePlanes();
			}



		}
	}
	public void OnTogglePlanes() {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag ("pla")) {
            MeshRenderer r = plane.GetComponent<MeshRenderer>();
			plane.GetComponent<DetectedPlaneVisualizer>().enabled = false;
            r.enabled = false;
        }
		GameObject planeRest = GameObject.FindGameObjectWithTag ("pm");
		planeRest.GetComponent<PlaneVisualizationManager>().enabled = false ;

		GameObject pointC = GameObject.FindGameObjectWithTag ("point");
		MeshRenderer r1 = pointC.GetComponent<MeshRenderer>();
		r1.enabled = false;
	}
}