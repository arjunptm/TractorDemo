using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CATMovement : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("MoveCAT") != 0)
        {
            rb.AddForce(0, 0, 10* Input.GetAxis("MoveCAT"));
            if (GetComponent<AudioSource>().pitch <= (float)0.20) GetComponent<AudioSource>().pitch += (float)0.01;
        }

        else if (Input.GetKey("up"))
        {
            rb.AddForce(0, 0, 10);
            if (GetComponent<AudioSource>().pitch <= (float)0.20) GetComponent<AudioSource>().pitch += (float)0.01;
        }

        else if (Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -10);
            if (GetComponent<AudioSource>().pitch <= (float)0.20) GetComponent<AudioSource>().pitch += (float)0.01;
        }

        else
        {
            GetComponent<AudioSource>().pitch = (float)0.09;
        }

        //Debug.Log(Input.GetAxis("MoveCAT"));
    }
}
