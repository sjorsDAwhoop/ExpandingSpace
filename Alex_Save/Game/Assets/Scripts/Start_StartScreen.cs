using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_StartScreen : MonoBehaviour
{

    public void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Lvl_1");
        }
    }
    
}
