using UnityEngine;


public class CreateSpell: ScriptableObject, ISpell {

    private string m_name = "CreateSpell";
    private string m_descr = "One is good...two is better !";
    private string m_sprite = "create";

    private Color m_particleColor = Color.yellow;
    private Color m_haloColor = Color.yellow;

    private GameObject m_clone;

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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider &&
            hit.collider.gameObject &&
            hit.collider.gameObject.tag == "Clonable")
        {
            if (m_clone)
            {
                Destroy(m_clone);
            }

            m_clone = Instantiate(hit.collider.gameObject);
            m_clone.AddComponent<FollowMousyMousy>();
            m_clone.GetComponent<BoxCollider2D>().enabled = false;
            Material[] mats = m_clone.GetComponent<Renderer>().materials;
            mats[0] = GameControllerScript.gmc.forClone;
            m_clone.GetComponent<Renderer>().materials = mats;
            m_clone.tag = "Clone";
        }
    }

    public void unApplyEffect()
    {
        if (m_clone && m_clone.GetComponent<FollowMousyMousy>())
        {
            m_clone.GetComponent<FollowMousyMousy>().enabled = false;
            m_clone.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
