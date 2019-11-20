using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibleOutOfMain : MonoBehaviour {

    GameControllerScript gmC;
	// Use this for initialization
	void Start () {
        gmC = GameObject.Find("GameController").GetComponent<GameControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gmC.activeLevel != "MainTitle")
            this.gameObject.GetComponent<Text>().enabled = false;
        else
            this.gameObject.GetComponent<Text>().enabled = true;
    }
}
