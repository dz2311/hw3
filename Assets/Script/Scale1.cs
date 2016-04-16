using UnityEngine;
using System.Collections;

public class Scale1 : MonoBehaviour {
	public Select script;
	private GameObject selectObj;
	private Vector3 prev_pos;
	private Vector3 cur_pos;
	// Use this for initialization
	void Start () {
		selectObj = null;
		prev_pos = new Vector3(1000f, 1000f, 1000f);
		cur_pos = prev_pos;
	}
	
	// Update is called once per frame
	void Update () {
		selectObj = script.GetComponent<Select> ().getSelected ();
		cur_pos = transform.position;
		if (cur_pos!=new Vector3(1000f, 1000f, 1000f)&&selectObj != null) {
			if (prev_pos != new Vector3 (1000f, 1000f, 1000f)) {
				float scale = (cur_pos.y - prev_pos.y) / 2f;
				if (scale > 1) {
					selectObj.transform.localScale = new Vector3 (scale/5f, scale/5f, scale/5f);
					prev_pos = cur_pos;
				} else if (scale < -1) {
					selectObj.transform.localScale = new Vector3 (0.1f / -scale, 0.1f / -scale, 0.1f / -scale);
					prev_pos = cur_pos;
				} else {
				}
			} else {
				prev_pos = cur_pos;
			}
		}
	}
}
