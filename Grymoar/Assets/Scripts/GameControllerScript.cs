using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    [System.Serializable]
    public class Level
    {
        public string levelName;
        public GameObject level;
    }

    public Material forClone;
    public GameObject witchTransf;
    public GameObject paneDisplay;
    public AudioSource dieS;
    public string activeLevel = "MainTitle";
    public Level[] levels;
    public GameObject spawnPoint;
    public Dictionary<string, GameObject> levelS = new Dictionary<string, GameObject>();
    public static GameControllerScript gmc;
    public GameObject witch;

    private void Awake()
    {
        if (gmc)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            gmc = this;
        }
    }
    // Use this for initialization
    void Start () {
        InitiateDictionary();
        witch = GameObject.Find("Witch");
        if (activeLevel != "MainTitle")
            loadLevel(activeLevel);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            loadLevel("MainTitle");
            GameObject.Find("Timer").GetComponent<TimerScript>().stop();
            GameObject.Find("Timer").GetComponent<TimerScript>().reset();
        }
	}

    public void loadLevel(string level)
    {
        if (level != "MainTitle")
            GameObject.Find("Timer").GetComponent<TimerScript>().launch();
        if (level != "MainTitle")
            paneDisplay.SetActive(true);
        levelS[activeLevel].SetActive(false);
        levelS[level].SetActive(true);
        activeLevel = level;
        GameObject newWitch = Instantiate(witchTransf);
        newWitch.transform.position = spawnPoint.transform.position;
        Destroy(witch);
        witch = newWitch;

    }

    public void die()
    {
        if (dieS)
            dieS.Play();
        witch.transform.position = spawnPoint.transform.position;
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject clone in clones)
            Destroy(clone);
    }

    private void InitiateDictionary()
    {
        foreach (Level lvl in levels)
        {
            levelS.Add(lvl.levelName, lvl.level);
        }
    }
}
