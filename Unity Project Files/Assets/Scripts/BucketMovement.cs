using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BucketMovement : MonoBehaviour
{
    public GameObject Truck;
    private Vector3 offset;
    public Vector3 elevation;
    // Start is called before the first frame update
    void Start()
    {
        offset = Truck.transform.position - transform.position;
        elevation = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Truck.transform.position - offset + elevation;

        if (Input.GetAxis("MoveBucket") != 0)
        {
            elevation.y += (float)Input.GetAxis("MoveBucket")/7;
            Debug.Log(Input.GetAxis("MoveBucket"));
            if (elevation.y > 0.25)
            {
                elevation.y = (float)0.25;
            }
            if (elevation.y < -0.24)
            {
                elevation.y = (float)-0.24;
            }
        }

        else if (Input.GetKey("w"))
        {
            if (elevation.y <= 0.25) elevation.y += (float) 0.01;
        }

        else if (Input.GetKey("s"))
        {
            if (elevation.y > -0.24) elevation.y -= (float)0.01;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hello");
            GetComponent<Renderer>().material.color = Color.red;
            Invoke("Restart", 2f);

        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
