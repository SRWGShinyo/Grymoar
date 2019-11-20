using UnityEngine;


public class TimeSpell: ScriptableObject, ISpell {

    private string m_name = "TimeSpell";
    private string m_descr = "Sloooooooooooowwwww";
    private string m_sprite = "time";

    private Color m_particleColor = Color.magenta;
    private Color m_haloColor = Color.magenta;

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
        GameObject[] timer = GameObject.FindGameObjectsWithTag("Time");
        foreach (GameObject go in timer)
        {
            go.GetComponent<MovingFAST>().step = 0.05f;
        }
    }

    public void unApplyEffect()
    {
        GameObject[] timer = GameObject.FindGameObjectsWithTag("Time");
        foreach (GameObject go in timer)
        {
            go.GetComponent<MovingFAST>().step = 0.8f;
        }
    }
}
