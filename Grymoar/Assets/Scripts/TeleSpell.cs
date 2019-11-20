using UnityEngine;


public class TeleSpell: ScriptableObject, ISpell {

    private string m_name = "TeleSpell";
    private string m_descr = "Walking is sooo tiring";
    private string m_sprite = "teleport";

    private Color m_particleColor = Color.green;
    private Color m_haloColor = Color.green;

    private bool isTeleporting = false;

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
            hit.collider.gameObject.tag == "Teleporter" && !isTeleporting)
        {
            isTeleporting = true;

            GameObject teleporter = hit.collider.gameObject;
            teleporter.GetComponent<AudioSource>().Play();
            GameObject witch = GameObject.Find("GameController").GetComponent<GameControllerScript>().witch;
            ParticleSystem telepEffect = GameObject.Find("Teleport").GetComponent<ParticleSystem>();

            ParticleSystem cloneTp = Instantiate(telepEffect) as ParticleSystem;
            Vector3 toInstantiate = witch.transform.position;
            cloneTp.transform.position = toInstantiate;
            witch.SetActive(false);
            witch.transform.position = teleporter.transform.position;
            cloneTp.Play();
            teleporter.GetComponentInChildren<ParticleSystem>().Play();
            witch.SetActive(true);
        }
    }

    public void unApplyEffect()
    {
        isTeleporting = false;
    }
}
