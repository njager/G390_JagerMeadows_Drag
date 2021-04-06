using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour
{

    public GameObject playerwin;
    public GameObject npcwin;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerwin.SetActive(true);
        }

        if (other.gameObject.tag == "opponent")
        {
            npcwin.SetActive(true);
        }
    }
}
