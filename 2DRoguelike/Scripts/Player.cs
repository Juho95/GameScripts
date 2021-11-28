using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //config
    public float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    public float knockbackThreshold = 3.5f;

    public bool isGrounded = false;
    public float jumpHeight = 5f;


    bool jump = false;


    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;



    Rigidbody2D myRigidBody;
    Animator myAnimator;
    public GameObject roguelikeStatsCanvas;



    //Message then methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Dash();
        //  FlipSprite();

    }
    private void FixedUpdate()
    {
        Run();
        if (isGrounded == true)
        {
            jump = false;
            myAnimator.SetBool("isJumping", false);
        }
    }

    private void Run()
    {
        // Ohjainta varten float arvoilla rajattu toimii myös näppäimistöllä
        // Joystick antaa float arvon -1 ja 1 väliltä ja keyboard -1, 0 tai 1
        // Ohjaimella deadzone -0,5 ja 0,5 välillä eli pieni tatin siirto ei liikuta hahmoa
        if ((Input.GetAxisRaw("Horizontal") < -0.5 || Input.GetAxisRaw("Horizontal") >= 0.5) || (Input.GetAxisRaw("Vertical") < -0.5 || Input.GetAxisRaw("Vertical") >= 0.5))
        {
            // Pyöristetään horizontalista tulevat luvut kokonaisluvuiksi
            //Debug.Log("velo" + myRigidBody.velocity.x);
            if (myRigidBody.velocity.x >= -knockbackThreshold && myRigidBody.velocity.x <= knockbackThreshold)
            {
                transform.Translate((int)Math.Round(Input.GetAxisRaw("Horizontal")) * runSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetAxisRaw("Horizontal") < -0.5)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetAxisRaw("Horizontal") >= 0.5)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            // Estää ilmassa kävelyn
            if (!myAnimator.GetBool("isInAir"))
            {
                myAnimator.SetBool("Running", true);
            }
            else
            {
                myAnimator.SetBool("Running", false);
            }
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }

    }



    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            jump = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            myAnimator.SetBool("isJumping", true);
        }

    }

    private void Dash()
    {

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.C) && isGrounded == true)
            {
                gameObject.layer = 11;
                direction = 1;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                myAnimator.SetBool("dash", false);
                direction = 0;
                dashTime = startDashTime;
                myRigidBody.velocity = Vector2.zero;
                gameObject.layer = 8;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if(gameObject.transform.localScale.x == -1)
                {
                    myAnimator.SetBool("dash", true);
                    myRigidBody.velocity = Vector2.right * dashSpeed;
                }
                else if (gameObject.transform.localScale.x == 1)
                {
                    myAnimator.SetBool("dash", true);
                    myRigidBody.velocity = Vector2.left * dashSpeed;
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            roguelikeStatsCanvas.SetActive(true);
        }
    }


}
