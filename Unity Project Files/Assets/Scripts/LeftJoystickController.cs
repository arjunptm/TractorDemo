using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftJoystickController : MonoBehaviour
{
    public Vector3 initialRotation;
    public Vector3 forwardRotation;
    public Vector3 reverseRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("MoveCAT") > 0 || Input.GetKey("up"))
        {
            transform.eulerAngles = forwardRotation;
        }

        else if (Input.GetAxis("MoveCAT") < 0 || Input.GetKey("down"))
        {
            transform.eulerAngles = reverseRotation;
        }

        else
        {
            transform.eulerAngles = initialRotation;
        }
    }
}
