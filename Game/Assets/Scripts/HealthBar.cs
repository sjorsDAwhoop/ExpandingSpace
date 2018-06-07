using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public static int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    

    private void Update()
    {
        for (int i= 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;

            } else
            {
                hearts[i].enabled = false;
            }
        }

        if (Input.GetKey(KeyCode.U)) {
            health -= 1;
        }

        if (Input.GetKey(KeyCode.I))
        {
            health += 1;
        }

    }
}
