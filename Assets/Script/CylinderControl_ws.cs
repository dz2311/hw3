using UnityEngine;
using System.Collections;


public class CylinderControl_ws : MonoBehaviour {

	public WorkspaceControl script;
	private GameObject selectedObj;
	private GameObject wsCopy;
	private GameObject control;
	private GameObject ws;
	private Vector3 prev_pos;
	private Vector3 cur_pos;

	void Start () {
		ws = GameObject.Find ("Workspace");
		selectedObj = null;
		wsCopy = null;
		control = GameObject.Find ("CylinderSwitch");
		prev_pos = new Vector3 (0f, 0f, 0f);
		cur_pos = new Vector3 (0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update () {
		selectedObj = script.GetComponent<WorkspaceControl> ().getSelected ();
		wsCopy = script.GetComponent<WorkspaceControl> ().getCopy ();
		cur_pos = control.transform.position;
		if (Mathf.Abs (cur_pos.x - prev_pos.x) < 20 && Mathf.Abs (cur_pos.y - prev_pos.y) < 10 && Mathf.Abs (cur_pos.z - prev_pos.z )< 20) {
			wsCopy.transform.position = ws.transform.position + (cur_pos - prev_pos);
			selectedObj.transform.localPosition = wsCopy.transform.localPosition;
		}
		prev_pos = cur_pos;
		//}
	}
}
