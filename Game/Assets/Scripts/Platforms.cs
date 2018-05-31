using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    private PlatformEffector2D effector;
    public float waitTime;
    bool Under_Platform = false;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Under_Platform == true)
        {
            if (waitTime <= 0){
                effector.rotationalOffset = 0f;
                Under_Platform = false;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
                Under_Platform = true;

            }
            

        }
        if (Input.GetKey(KeyCode.W))
        {
            effector.rotationalOffset = 0f;
            
        }
    }
}
