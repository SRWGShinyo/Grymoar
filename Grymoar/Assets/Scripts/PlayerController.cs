using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpVelocity;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsGround2;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (!isGrounded)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround2);
        animator.SetBool("IsGrounded", isGrounded);

        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        animator.SetInteger("InputForce", (int)moveHorizontal);
        transform.localPosition += new Vector3(moveHorizontal, 0, 0) * Time.deltaTime * speed;
    }

    private void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Borders")
        {
            GameObject.Find("GameController").GetComponent<GameControllerScript>().die();
        }
    }
} 
