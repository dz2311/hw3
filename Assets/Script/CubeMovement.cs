using UnityEngine;
using System.Collections;

public class CubeMovement : MonoBehaviour {
	private Material ini_mat;
	private bool select_flag;
	// Use this for initialization
	void Start () {
		select_flag = false;
		ini_mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if(!select_flag)
			GetComponent<Renderer> ().material = ini_mat;
	}
	void Select(Material New_Material){
		select_flag = true;
		GetComponent<Renderer> ().material = New_Material;
	}

	void Deselect(){
		select_flag = false;
		GetComponent<Renderer> ().material = ini_mat;
	}
}
