using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarMoveForward : MonoBehaviour
{
    [SerializeField] private bool shiftHeld = false;
    [SerializeField] private float carSpeedNormal = 15f;
    [SerializeField] private float speedAcceleration = 0f;
    [SerializeField] private float turnAcelleration = 0f;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float carTurn1 = 0.3f;
    [SerializeField] private float carTurn2 = 0.3f;


    void Update()
    {
        // forwards
        if (Input.GetKey(KeyCode.S) && shiftHeld == false)
        {
            {
                transform.Translate(Vector3.forward * Time.deltaTime * carSpeedNormal);
            }
        }
        else if (Input.GetKey(KeyCode.S) && shiftHeld == true)
        {
            {
                transform.Translate(Vector3.forward * Time.deltaTime * carSpeedNormal * speedAcceleration);
            }
        }

        //backwards


        if (Input.GetKey(KeyCode.W) && shiftHeld == false)
        {
            {
                transform.Translate(Vector3.back * Time.deltaTime * carSpeedNormal);
            }
        }
        else if (Input.GetKey(KeyCode.W) && shiftHeld == true)
        {
            {
                transform.Translate(Vector3.back * Time.deltaTime * carSpeedNormal * speedAcceleration);
            }
        }









        // accelleration



        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftHeld = true;  //maybe
            Debug.Log("ShiftDown");

            if (speedAcceleration < 1.5)
            {
                speedAcceleration += 0.01f;
                turnAcelleration += 0.01f;
            }
        }



        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftHeld = false; //maybe
            Debug.Log("Shiftup");

        }

        if (shiftHeld == false)
        {
            if (speedAcceleration > 0)
            {
                speedAcceleration -= -0.1f;
                turnAcelleration -= -0.1f;
            }
            else if (speedAcceleration < 0)
            {
                speedAcceleration = 0;
                turnAcelleration = 0;
                Debug.Log("speed is lowest");
            }
        }






        // turning
         


        if (Input.GetKey(KeyCode.D))
        {
            {
                //rotate
                transform.Rotate(0, carTurn1, 0 * Time.deltaTime * turnSpeed);
            }
        }





        if (Input.GetKey(KeyCode.A))
        {
            {
                // rotate
                transform.Rotate(0, carTurn2, 0 * Time.deltaTime * turnSpeed);
            }
        }




    }

}
