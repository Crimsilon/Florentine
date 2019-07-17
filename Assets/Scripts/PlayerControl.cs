using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // location to determin where the ground is
    // Start is called before the first frame update
    private float moveInput;
    public float moveSpeed;
    public float jumpPower;
    public bool facingRight;
    public bool grounded= false;
    const float k_GroundedRadius = .1f;                     // Radius of the overlap circle to determine if grounded
    public Animator animator;
    public bool crouch;
    public bool canFire;
    public float hitStunDuration;
    public float flashSpeed;

    // Update is called once per frame
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10, true);

        canFire = true;
    }


    private void FixedUpdate()
    {
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
    }
    void Update()
    {

        moveInput = Input.GetAxis("Horizontal");
        
        Jump();

        isCrouching();
 
        Vector2 movement = new Vector2(moveInput * moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (!crouch)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = movement;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
        animator.SetFloat("Speed", (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x)/10));

        animator.SetFloat("YVelocity", (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) / 10));


        if (facingRight == false && moveInput > 0)
        {
            flip();
        }

        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }

    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetButtonDown("Jump") && grounded == true))
        { 
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        
    }

    void isCrouching()
    {

        bool joystickCrouch = (Input.GetAxis("crouch") > 0f);

        if (Input.GetKeyDown(KeyCode.S) || joystickCrouch)
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.S)|| joystickCrouch)
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }
    }

    //check if hit by an an enemy and assign hit stun;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
            bopped();
    }

    public void bopped()
    {
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        // gameObject.GetComponent<Rigidbody2D>().Sleep();
        animator.SetTrigger("Hit");
        // gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Physics2D.IgnoreLayerCollision(9, 10, true);

        StartCoroutine(EnableBox(hitStunDuration));

        StartCoroutine(Flash());
        canFire = false;
        yield return new WaitForSeconds(hitStunDuration);
        canFire = true;
    }

    IEnumerator Flash()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);
        yield return new WaitForSeconds(flashSpeed);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
   


    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Physics2D.IgnoreLayerCollision(9, 10, false);

        //gameObject.GetComponent<Rigidbody2D>().WakeUp();

        // gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }


}
