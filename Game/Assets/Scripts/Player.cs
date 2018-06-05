using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public AudioSource JumpSound;
    public float speedwalk = 0.1f;
    public float jumpheight = 12f;
    public bool isgrounded = true;

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

       //move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedwalk, 0, 0 * Time.deltaTime);
            spriteRenderer.flipX = true;
            animator.SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk", false);
        }
        
        //move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedwalk, 0, 0 * Time.deltaTime);
            spriteRenderer.flipX = false;
            animator.SetBool("Walk",true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walk", false);
        }


        //jump
        if (isgrounded == true && Input.GetKeyDown(KeyCode.W))
        {

            {
                rb.velocity = new Vector3(0, jumpheight, 0);
                JumpSound.Play();
                animator.SetBool("Jump", true);
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Jump", false);
        }
        
        //shoot
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("Shoot", true);
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            animator.SetBool("Shoot", false);
        }
    }


    void OnCollisionStay2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Platform" || theCollision.gameObject.tag == "Moving_Platform")
        {
            isgrounded = true;
            

        }
        if (theCollision.gameObject.tag == "Floor")
        {

            isgrounded = true;
           

        }

        if (theCollision.gameObject.tag == "Lava")
        {
            
            transform.position = new Vector3(-23, 2, 0);
           
        }

        if (theCollision.gameObject.tag == "enemy")
        {
            animator.SetBool("hit", true);
        }

    }


    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Platform" || theCollision.gameObject.tag == "Moving_Platform")
        {
            isgrounded = false;
            this.transform.parent = theCollision.transform;
           
       
        }
        if (theCollision.gameObject.tag == "Floor")
        {
            isgrounded = false;
            this.transform.parent = null;

        }

    }
    

  
}