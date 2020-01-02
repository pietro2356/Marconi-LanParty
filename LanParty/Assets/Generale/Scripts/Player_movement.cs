using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    FirstLevel_script level;
    Dialog_Manager dm;
    private float movement = 0f;
    [SerializeField] private LayerMask layer;
    private float originalGravity,
        climbingVelocity;



    public float movementVelocity = 0f,
        jumpForce = 0f,
        climbingSpeed = 0f;

    public bool onLadder = false;
        

    private bool isGrounded()
    {
        RaycastHit2D raycast = Physics2D.CircleCast(circleCollider.bounds.center, circleCollider.radius, Vector2.down * .1f, 0.1f, layer);
        return raycast;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        originalGravity = rb.gravityScale;
        level = FindObjectOfType<FirstLevel_script>();
        dm = FindObjectOfType<Dialog_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!level.stopped && !dm.inDialog)
        {
            movement = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(movement * movementVelocity, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.W) && isGrounded())
                rb.velocity = Vector2.up * jumpForce;


            if (onLadder)
            {
                rb.gravityScale = 0;

                climbingVelocity = climbingSpeed * Input.GetAxisRaw("Vertical");

                rb.velocity = new Vector2(rb.velocity.x, climbingVelocity);
            }
            else
                rb.gravityScale = originalGravity;
        }
        else
            rb.velocity = Vector2.zero;
    }

}
