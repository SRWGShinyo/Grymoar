using UnityEngine;

public class ShadowController : MonoBehaviour {

    public float speed;
    public float jumpVelocity;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetInteger("HoziontalForce", (int)moveVertical);
        animator.SetInteger("InputForce", (int)moveHorizontal);
        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical*speed);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(Vector2.up * jumpVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {

            GameObject witch = GameObject.Find("GameController").GetComponent<GameControllerScript>().witch;
            SpellController spC =  witch.GetComponent<SpellController>();
            PlayerController pC = witch.GetComponent<PlayerController>();
            spC.allAvailableSpells.Add(collision.gameObject.GetComponent<SpellContainer>().onPickUp());
            ParticleSystem pe = collision.gameObject.GetComponentInChildren<ParticleSystem>();
            ParticleSystem pE = Instantiate(pe) as ParticleSystem;
            pE.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            pE.Play();
            spC.activeSpell = spC.allAvailableSpells.Count - 1;
            spC.setUpSpell(spC.allAvailableSpells[spC.allAvailableSpells.Count - 1]);
            pC.enabled = true;
            Destroy(gameObject);
        }
    }
} 
