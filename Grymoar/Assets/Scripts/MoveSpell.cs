using UnityEngine;


public class MoveSpell: ScriptableObject, ISpell {

    private string m_name = "MoveSpell";
    private string m_descr = "I would place this...further to the right.";
    private string m_sprite = "move";

    private Color m_particleColor = Color.cyan;
    private Color m_haloColor = Color.cyan;

    private GameObject _isMoving;

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
            hit.collider.gameObject.tag == "Movable")
        {
            hit.collider.gameObject.GetComponent<MoveScript>().enabled = true;
            _isMoving = hit.collider.gameObject;
            MoveScript mvS = _isMoving.GetComponent<MoveScript>();
            Material[] mats = _isMoving.GetComponent<Renderer>().materials;
            mats[0] = mvS.onSelected;
           _isMoving.GetComponent<Renderer>().materials = mats;
        }
    }

    public void unApplyEffect()
    {
        if (_isMoving)
        {
            MoveScript mvS = _isMoving.GetComponent<MoveScript>();
            Material[] mats = _isMoving.GetComponent<Renderer>().materials;
            mats[0] = mvS.onUnSelected;
            _isMoving.GetComponent<Renderer>().materials = mats;
            _isMoving.GetComponent<MoveScript>().enabled = false;
            _isMoving = null;
        }
    }
}
