using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour
{
  public PropellerBoats ship;
  bool forward = true;

  void Update()
  {

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
