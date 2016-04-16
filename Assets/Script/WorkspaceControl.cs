using UnityEngine;
using System.Collections;
using Vuforia;

public class WorkspaceControl : MonoBehaviour {
	public Material New_Material;
	private GameObject selectObj;
	private GameObject initialObj;
	private GameObject cube_prev;
	private GameObject cube_next;
	private GameObject prev_select;
	private GameObject controlObj;
	public Select script;
	private bool trans_flag;
	private Vector3 newPos;
	// Use this for initialization
	void Start () {
		prev_select = null;
		selectObj = null;
		initialObj = null;
		trans_flag = false;
		controlObj = GameObject.Find ("CylinderTarget");
		newPos = new Vector3 (0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		selectObj = script.GetComponent<Select> ().getSelected ();
		if (selectObj != null) {
			selectObj.SendMessage ("Deselect");
			if (this.transform.childCount == 1 && prev_select.GetInstanceID () != selectObj.GetInstanceID ()) {
				Destroy (this.transform.GetChild (0).gameObject);
			}
			if (prev_select==null||selectObj.GetInstanceID () != prev_select.GetInstanceID ()) {
				Vector3 oriScale = selectObj.transform.localScale;
				initialObj = Instantiate (selectObj);
				initialObj.transform.parent = this.transform;
				initialObj.transform.localScale = oriScale;
				initialObj.transform.localPosition = new Vector3 (0f, 0f, 0f);
				prev_select = selectObj;
			}
			if (selectObj.GetInstanceID () == prev_select.GetInstanceID ()) {
				Vector3 oriScale = selectObj.transform.localScale;
				initialObj.transform.localScale = oriScale;
				//initialObj = Instantiate (selectObj);
				initialObj.transform.rotation = selectObj.transform.rotation;
			}
			selectObj.SendMessage ("Select", New_Material);
		} else {
			if(this.transform.childCount==1)
				Destroy (this.transform.GetChild (0).gameObject);
			prev_select = null;
			selectObj = null;
		}
	}
	public void CreateObject()
	{
		GameObject oriTagCopy = Instantiate (initialObj);
		GameObject oriImg = GameObject.Find ("ImageTarget");
		Vector3 trsScale = initialObj.transform.localScale;
		oriTagCopy.transform.parent = oriImg.transform;
		oriTagCopy.transform.localScale = trsScale;
		oriImg.transform.localPosition = newPos;
		newPos += new Vector3 (1f, 1f, 1f);
	}
	public void DeleteObject()
	{
		if (selectObj != null)
			selectObj.SendMessage ("Deselect");
		Destroy (selectObj);
	}
	public void ReScale_up()
	{
		this.transform.localScale += new Vector3 (2f, 2f, 2f);
	}
	public void ReScale_down()
	{
		this.transform.localScale -= new Vector3 (2f, 2f, 2f);
	}
	public void connectCylinder()
	{
		if (initialObj != null) {
			trans_flag = true;
			Vector3 rescale = initialObj.transform.localScale;
			initialObj.transform.parent = controlObj.transform;
			initialObj.transform.localScale = rescale;
		}

	}
	public void disconnectCylinder()
	{
		if(trans_flag)
		{
		trans_flag = false;
		Vector3 rescale = initialObj.transform.localScale;
		initialObj.transform.parent = this.transform;
		selectObj.transform.localPosition = initialObj.transform.localPosition;
		selectObj.transform.localScale = rescale;
		}
	}
	public GameObject getSelected()
	{
		return selectObj;
	}

	public GameObject getCopy()
	{
		if(this.transform.childCount==1)
			return initialObj;
		else {
			return null;
		}
	}

}
