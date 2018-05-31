using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Frame : MonoBehaviour {


    public GameObject a;
    public Quest item;


    void Start () {
        item = a.GetComponent<Quest>();

    }
	
	
	void Update () {
         

        if (item.Pickable1 == 1)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        if (item.Pickable1 == 2)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
