using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public AudioSource CollectSound;




    void Start()
    {
        
    }


    void Update()
    {

        //Quest 1
        if (Input.GetKeyDown("p") && (Quest1 == true))
        {
            if (Pickable1 == 0)
            {
                Debug.Log("Bring me stuff");
            }
            else if (Pickable1 == 2)
            {
                Debug.Log("No help needed");
            }
            else if (Pickable1 == 1)
            {
                Debug.Log("Thanks for getting me stuff");
                Pickable1 = 2;
            }
        }
    }

    public bool Quest1 = true;
    public int Pickable1 = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Quest 1
        if (collision.gameObject.tag == "NPC_1")
        {
            Quest1 = true;
        }

        if (collision.gameObject.tag == "Pickable_1")
        {
            Pickable1 = 1;
            Destroy(collision.gameObject);
            CollectSound.Play();
        }
        if (collision.gameObject.tag == "Ending" && Pickable1 == 2)
        {
            SceneManager.LoadScene("`Loading");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Quest 1
        if (collision.gameObject.tag == "NPC_1")
        {
            Quest1 = false;
        }
    }
}

