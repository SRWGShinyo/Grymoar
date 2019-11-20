using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousyMousy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Cursor.visible)
            Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
	}
}
