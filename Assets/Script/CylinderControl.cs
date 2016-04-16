using UnityEngine;
using System.Collections;

public class CylinderControl : MonoBehaviour {
	private bool select_flag;
	//private bool scale_flag;
	private GameObject selectedObject;
	private Material ini_mat;
	// Use this for initialization
	void Start () {
		select_flag = false;
		//scale_flag = false;
		selectedObject = null;
		//childElement = transform.FindChild ("LightElement").gameObject;
		//childElement.SetActive (false);
		ini_mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (select_flag) {
			//childElement.SetActive (true);

		} else {
			//childElement.SetActive (false);
			GetComponent<Renderer> ().material = ini_mat;
		}
		if (selectedObject != null) {
			//get cyclinder's coordinates change in y Axsis

		}
	}
	void Select(Material New_Material){
		select_flag = true;
		GetComponent<Renderer> ().material = New_Material;
	}

	void Deselect(){
		select_flag = false;
	}
}
