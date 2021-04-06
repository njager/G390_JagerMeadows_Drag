using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{

    public bool oob; 

    void Start()
    {
        oob = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "oob")
        {
            oob = true; 
        }
    }
}
