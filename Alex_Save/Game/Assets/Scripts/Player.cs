using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    }

    void Update()
    {

       



        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedwalk, 0, 0 * Time.deltaTime);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedwalk, 0, 0 * Time.deltaTime);
            spriteRenderer.flipX = false;
        }



        
        if (isgrounded == true && Input.GetKeyDown(KeyCode.W))
        {

            {
                rb.velocity = new Vector3(0, jumpheight, 0);
                JumpSound.Play();
            }
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