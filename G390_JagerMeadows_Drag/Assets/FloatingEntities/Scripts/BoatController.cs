using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{
  public PropellerBoats ship;
  bool forward = true;
    private Rigidbody thisRigidbody;
    public AudioClip impact;
    AudioSource audioSource; 

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "oob")
        {
            thisRigidbody.transform.Rotate(0.0f, 100.0f, 0.0f, Space.World);
            thisRigidbody.transform.position = CheckPoint.GetActiveCheckPointPosition();
            audioSource.PlayOneShot(impact, 0.7F); 

        }
    } 

    void Update()
  {

        //IF YOU GET STUCK,, REASSIGN THIS TO A CONTROLLER BUTTTON 
        if (Input.GetKeyDown("space"))
        {
            thisRigidbody.transform.Rotate(0.0f, 100.0f, 0.0f, Space.World);
            thisRigidbody.transform.position = CheckPoint.GetActiveCheckPointPosition();
        }

        //IF YOU GET RESTARTS THE SCENE,, REASSIGN THIS TO A CONTROLLER BUTTTON 
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 

        /*if (Input.GetKey(KeyCode.Q))
          ship.RudderLeft();
        if (Input.GetKey(KeyCode.D))
          ship.RudderRight();*/

        if (Input.GetAxis("Horizontal") < 0)
      ship.RudderLeft();
    if (Input.GetAxis("Horizontal") > 0)
      ship.RudderRight();

    if (forward)
    {
      if (Input.GetKey(KeyCode.JoystickButton5))
        ship.ThrottleUp();
      else if (Input.GetKey(KeyCode.JoystickButton4))
      {
        ship.ThrottleDown();
        ship.Brake();
      }
    }
    else
    {
      if (Input.GetKey(KeyCode.JoystickButton4))
        ship.ThrottleUp();
      else if (Input.GetKey(KeyCode.JoystickButton5))
      {
        ship.ThrottleDown();
        ship.Brake();
      }
    }

    if (!Input.GetKey(KeyCode.JoystickButton5) && !Input.GetKey(KeyCode.JoystickButton4))
      ship.ThrottleDown();

    if (ship.engine_rpm == 0 && Input.GetKey(KeyCode.JoystickButton4) && forward)
    {
      forward = false;
      ship.Reverse();
    }
    else if (ship.engine_rpm == 0 && Input.GetKey(KeyCode.JoystickButton5) && !forward)
    {
      forward = true;
      ship.Reverse();
    }
  }

}
