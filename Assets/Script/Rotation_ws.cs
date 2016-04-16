using UnityEngine;
using System.Collections;

public class Rotation_ws : MonoBehaviour {

		public WorkspaceControl script;
		private GameObject wsCopy;
		private GameObject selectedObj;
		private Vector3 prev_pos;
		private Vector3 cur_pos;
		// Use this for initialization
		void Start () {
			selectedObj = null;
		prev_pos = transform.position;
		cur_pos = prev_pos;
		}

		// Update is called once per frame
		void Update () {
			selectedObj = script.GetComponent<WorkspaceControl> ().getSelected ();
			wsCopy = script.GetComponent<WorkspaceControl> ().getCopy ();
		if (cur_pos!=new Vector3(1000f, 1000f, 1000f)&&selectedObj != null) {
				cur_pos = transform.position;
				if ((cur_pos.y - prev_pos.y) / 2 > 1) {
					wsCopy.transform.Rotate (Vector3.up * Time.deltaTime*(cur_pos.y-prev_pos.y)*1000);
					selectedObj.transform.Rotate (Vector3.up * Time.deltaTime*(cur_pos.y-prev_pos.y)*1000);
					prev_pos = cur_pos;
				} else {
					wsCopy.transform.Rotate (Vector3.up * Time.deltaTime*(cur_pos.y-prev_pos.y)*1000);
					selectedObj.transform.Rotate (Vector3.up * Time.deltaTime*(cur_pos.y-prev_pos.y)*1000);
					prev_pos = cur_pos;
				}
			}
		}
}
