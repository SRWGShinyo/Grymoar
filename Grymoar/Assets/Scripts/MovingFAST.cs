
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFAST : MonoBehaviour {

    public float minX = -1f;
    public float maxX = 8.5f;
    public float step = 0.8f;

    bool goLeft = true;
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = gameObject.transform.position;
        if (pos.x > maxX)
            goLeft = true;
        if (pos.x < minX)
            goLeft = false;

        float newX = goLeft ? pos.x - step : pos.x + step;
        transform.position = new Vector3(newX, pos.y, pos.z);
	}
}
