using UnityEngine;
using UnityEngine.UI;

public class SignScript : MonoBehaviour {

    public static SignScript activatedSign = null;

    public string[] messageToDisplay;
    public GameObject panelDisplay;
    private Text displayer;
    public GameObject enterSign;

    public bool isSomethingOn = false;
    public bool hasSetUp = false;

	// Use this for initialization
	void Start () {
        panelDisplay = GameObject.Find("Tabpanel");
        displayer = panelDisplay.GetComponentInChildren<Text>();
        enterSign = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
        enterSign.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Sign up !");
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasSetUp)
        {
            panelDisplay.SetActive(false);
            hasSetUp = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && activatedSign == this)
        {
            if (panelDisplay.activeSelf)
                panelDisplay.SetActive(false);

            else if (isSomethingOn)
            {
                panelDisplay.SetActive(true);
                displayer.text = "";
                foreach (string s in messageToDisplay)
                    displayer.text += s + "\n";
                GameObject.Find("SignPan").GetComponent<AudioSource>().Play();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shadow")
        {
            isSomethingOn = true;
            enterSign.GetComponent<SpriteRenderer>().enabled = true;
            activatedSign = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shadow")
        {
            isSomethingOn = false;
            enterSign.GetComponent<SpriteRenderer>().enabled = false;
            panelDisplay.SetActive(false);
            activatedSign = null;
        }
    }
}
