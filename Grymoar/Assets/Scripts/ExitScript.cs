using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    public string levelToLoad;

    private GameObject enterInfo;
    private bool isSomethingOn;
	// Use this for initialization
	void Start () {
        enterInfo = GameObject.Find("EnterTextExit");
        enterInfo.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && isSomethingOn)
        {
            GameObject.Find("GameController").GetComponent<GameControllerScript>().loadLevel(levelToLoad);
            GameObject.Find("Exit").GetComponent<AudioSource>().Play();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enterInfo.GetComponent<SpriteRenderer>().enabled = true;
            isSomethingOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enterInfo.GetComponent<SpriteRenderer>().enabled = false;
            isSomethingOn = false;
        }
    }
}
