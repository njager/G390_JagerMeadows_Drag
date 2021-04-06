using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishline : MonoBehaviour
{

    public GameObject playerwin;
    public GameObject npcwin;
    public Text timeText;
    public float startTime = 0f;

    bool lapComplete = false;
    
    void FixedUpdate()
    {
        if(lapComplete == false)
        {
            startTime += Time.deltaTime;
            timeText.text = "Time: " + startTime;
    }
        }
        

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerwin.SetActive(true);
            lapComplete = true;
        }

        if (startTime == 100f)
        {
            npcwin.SetActive(true);
            lapComplete = true;
        }
    }
}
