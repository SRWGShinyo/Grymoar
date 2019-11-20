using UnityEngine;


public class MorphSpell: ScriptableObject, ISpell {

    private string m_name = "MorphSpell";
    private string m_descr = "Free your inner shadow";
    private string m_sprite = "morph";

    private Color m_particleColor = Color.red;
    private Color m_haloColor = Color.red;

    GameObject m_clone = null;

    public string nameS
    {
        get { return m_name; }
    }

    public string descr
    {
        get { return m_descr; }
    }

    public string sprite
    {
        get { return m_sprite; }
    }

    public Color particleColorGradient
    {
        get { return m_particleColor; }
    }

    public Color haloColor
    {
        get { return m_haloColor; }
    }

    public void applyEffect()
    {
        if (!m_clone)
        {
            GameObject clone = Instantiate(GameObject.Find("Shadow"));
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clone.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            m_clone = clone;
            GameObject.Find("GameController").GetComponent<GameControllerScript>().witch.GetComponent<PlayerController>().enabled = false;
            GameObject.Find("GameController").GetComponent<GameControllerScript>().witch.GetComponent<Animator>().SetInteger("InputForce", 0);
        }
    }

    public void unApplyEffect()
    {
        Destroy(m_clone);
        m_clone = null;
        GameObject.Find("GameController").GetComponent<GameControllerScript>().witch.GetComponent<PlayerController>().enabled = true;
    }
}
