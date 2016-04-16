using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	// Use this for initialization
	public Material New_Material;
	public LayerMask touchInputMask;
	private GameObject selected;
	private GameObject checkControl;
	private bool control_flag;
	private GameObject originParent_se;
	private GameObject originParent_re;
	// Update is called once per frame
	void Start(){
		selected = null;
		checkControl = GameObject.Find("CylinderSwitch");
		control_flag = false;
		originParent_se = GameObject.Find("ImageTarget");
		originParent_re = GameObject.Find ("CylinderTarget");
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, touchInputMask)) {
				if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject (-1)) {
					/*if (selected != null) {
						selected.SendMessage ("Deselect");
						selected = null;
					}*/
					GameObject recipient = hit.collider.gameObject;
					if (selected != null) {
						if (selected.GetInstanceID () == recipient.GetInstanceID ()) {
							recipient.SendMessage ("Deselect");
							selected = null;
						} else if (recipient.GetInstanceID () == checkControl.GetInstanceID ()) {
							selected.transform.parent = recipient.transform;
							control_flag = true;
							recipient.SendMessage ("Select", New_Material);
						} else if (selected.GetInstanceID () == checkControl.GetInstanceID ()) {
							recipient.transform.parent = selected.transform;
							control_flag = true;
							recipient.SendMessage ("Select", New_Material);
						} else {
							selected.SendMessage ("Deselect");
							selected = recipient;
							recipient.SendMessage ("Select", New_Material);
						}
					} //else if (selected.GetInstanceID () == checkControl.GetInstanceID ()&& selected != null && (recipient.GetInstanceID () != checkControl.GetInstanceID ())) {
						//recipient.transform.parent = selected.transform;
					else {
						selected = recipient;
						recipient.SendMessage ("Select", New_Material);
					}

				}
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit,touchInputMask)) {
				if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject (-1)) {
					GameObject recipient = hit.collider.gameObject;
					//if (recipient.GetInstanceID () == selected.GetInstanceID ()) {
						
					
						if (recipient.GetInstanceID () == checkControl.GetInstanceID ()&&control_flag) {
							selected = recipient.transform.GetChild (0).gameObject;
							selected.transform.parent = originParent_se.transform;
							selected.SendMessage ("Deselect");
							selected = null;
							control_flag = false;
							recipient.SendMessage ("Deselect");
						} else if (recipient.transform.parent.GetInstanceID () == checkControl.GetInstanceID ()&&control_flag) {
							selected = recipient.transform.parent.gameObject;
							selected.SendMessage ("Deselect");
							recipient.gameObject.transform.parent = originParent_se.gameObject.transform;
							recipient.SendMessage ("Deselect");
							control_flag = false;
							selected = null;
						} else {
							recipient.SendMessage ("Deselect");
							selected = null;
						}
					}
				}
			//} 
		}
	}
	public GameObject getSelected()
	{
		if(!control_flag)
			return selected;
		else
			return null;
	}
}

