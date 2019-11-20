using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseScript : MonoBehaviour {

    public GameObject congratsPanel;
    public bool isSomethingOn = false;
    public GameObject enterSign;
    // Use this for initialization
    void Start () {
        enterSign = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
        enterSign.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && isSomethingOn)
        {
            if (congratsPanel.activeSelf)
            {
                congratsPanel.SetActive(false);
                GameObject.Find("GameController").GetComponent<GameControllerScript>().loadLevel("MainTitle");
                GameObject.Find("Congrats").GetComponent<AudioSource>().Stop();
                GameObject.Find("Ambient").GetComponent<AudioSource>().Play();
                TimerScript tms = GameObject.Find("Timer").GetComponent<TimerScript>();
                tms.reset();
            }

            else
            {
                TimerScript tms = GameObject.Find("Timer").GetComponent<TimerScript>();
                tms.stop();
                congratsPanel.SetActive(true);
                GameObject.Find("FinalTime").GetComponent<Text>().text += "Your final time is " + tms.timerString + " (You could have done better...)";
                GameObject.Find("Ambient").GetComponent<AudioSource>().Stop();
                GameObject.Find("Congrats").GetComponent<AudioSource>().Play();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isSomethingOn = true;
            enterSign.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isSomethingOn = false;
            enterSign.GetComponent<SpriteRenderer>().enabled = false;
            if (congratsPanel.activeSelf)
            {
                congratsPanel.SetActive(false);
                GameObject.Find("Congrats").GetComponent<AudioSource>().Stop();
                GameObject.Find("Ambient").GetComponent<AudioSource>().Play();
            }
        }
    }
}
