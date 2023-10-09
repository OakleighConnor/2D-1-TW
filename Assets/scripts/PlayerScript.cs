using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{

        public float distanceToCheck = 0.5f;
        public bool isGrounded;
        public bool canMove = true;
    


        public float speed = 2f;

    public Sprite spriteDown;
    public Sprite spriteUp;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    

    private SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    Animator anim;




    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();



    }


    // Update is called once per frame
    void Update()
    {
        Color rayColour;



        

        if (canMove == true)
        {


            if (isGrounded == false)
            {
                anim.SetBool("idle", false);
            }
            else
            {
                anim.SetBool("idle", true);
            }

            //-----Controls--------

            //---JUMP---         (was UP)
            if (Input.GetKeyDown("space") && (isGrounded) == true)
            {

                rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);

                anim.SetBool("jump", true);
                anim.SetBool("run", false);
            }
            else if (isGrounded == true)
            {

                anim.SetBool("jump", false);

            }


            if (Input.GetKey("a") || Input.GetKey("d") == true)
            {

                //---LEFT---
                if (Input.GetKey("a") == true)
                {
                    transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
                    spriteRenderer.flipX = true;
                }




                //---RIGHT--
                if (Input.GetKey("d") == true)
                {
                    transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
                    spriteRenderer.flipX = false;
                }


                if (isGrounded == true)
                {
                    anim.SetBool("run", true);
                }
                else
                {
                    anim.SetBool("run", false);
                }


            }
            else
            {

                anim.SetBool("run", false);

            }

            //----ATTACK---
            if (Input.GetKey("q") == true)
            {
                anim.SetBool("attack", true);
            }
            else
            {
                anim.SetBool("attack", false);
            }

        }




        //-----------------------

        Vector3 offset = new Vector3(0, -0.0f, 0);
        if (Physics2D.Raycast(transform.position + offset, Vector2.down, distanceToCheck))
        {
            isGrounded = true;
            rayColour = Color.red;
        }
        else
        {
            isGrounded = false;
            rayColour = Color.white;
        }

        Debug.DrawRay(transform.position + offset, Vector2.down * distanceToCheck, rayColour);



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            anim.SetBool("idle", false);
            canMove = false;
            spriteRenderer.sprite = spriteDown;
        }
    }

}

//---Holding-things----
/*
 
 
//---(from UP controls)---

  transform.position = new Vector2 (transform.position.x, transform.position.y + (speed * Time.deltaTime) );
  if (spriteRenderer.sprite != spriteUp)
                {
                    spriteRenderer.sprite = spriteUp;
                }

//----(from DOWN controls)---
    transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));

    if (spriteRenderer.sprite != spriteDown)
                {
                    spriteRenderer.sprite = spriteDown;
                }

//----(from LEFT controls)---

if (spriteRenderer.sprite != spriteLeft)
                {
                    spriteRenderer.sprite = spriteLeft;
                }


//----(from RIGHT controls)---

     if (spriteRenderer.sprite != spriteRight)
                {
                        spriteRenderer.sprite = spriteRight;
                }



     //---FACE SCREEN---     (was DOWN)
            if (Input.GetKey("s") == true)
            {
                

            
            }



*/