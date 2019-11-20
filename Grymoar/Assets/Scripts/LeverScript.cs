using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {

    private Animator anim;

    public AudioSource sound;
    public bool isActivated = false;
    public bool isSomthingOn = false;
    public bool isToMakeAppear = true;

    public GameObject[] impact;

    private void Start()
    {
        anim = GetComponent<Animator>();
        foreach (GameObject go in impact)
            go.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (isSomthingOn && Input.GetKeyDown(KeyCode.E) && !isActivated)
            Activate();
	}

    public void Activate()
    {
        if (isToMakeAppear)
        {
            foreach (GameObject go in impact)
                go.SetActive(true);
        }
        else
        {
            foreach (GameObject go in impact)
                Destroy(go);
        }

        if (sound)
            sound.Play();
        isActivated = true;
        anim.SetBool("IsActivated", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shadow")
        {
            isSomthingOn = true;
            GameObject EKey = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
            if (EKey && !isActivated)
                EKey.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shadow")
        {
            isSomthingOn = false;
            GameObject EKey = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
            if (EKey)
                EKey.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
