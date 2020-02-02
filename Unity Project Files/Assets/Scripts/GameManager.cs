using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool levelCompleted = false;
    public Text text;
    public GameObject completeLevelUI;
    public GameObject bucket;
    public GameObject obstacle;
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("space") || Input.GetAxis("SetLevel") != 0)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        //if (SceneManager.GetActiveScene().name == ")
        //{
        if (levelCompleted == false)
        {
            float distVal = Mathf.Abs(bucket.transform.position.z - obstacle.transform.position.z) - (float)1.0;
            float heightVal = Mathf.Abs(bucket.transform.position.y - ground.transform.position.y) - (float)1.01;
            text.text = "Distance to object: " + distVal.ToString("F2") + "m\nDistance to ground: " + heightVal.ToString("F2") + "m";
            levelCompleted = true;
            completeLevelUI.SetActive(true);
        }
        //}
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    if (levelCompleted == false)
        //    {
        //        float distVal = Mathf.Abs(bucket.transform.position.z - obstacle.transform.position.z) - (float)0.90;
        //        float heightVal = Mathf.Abs(bucket.transform.position.y - ground.transform.position.y) - (float)1.01;
        //        text.text = "Distance to object: " + distVal.ToString("F2") + "m\nDistance to ground: " + heightVal.ToString("F2") + "m";
        //        text.text += "\n\nDid you perform better?\n\nNow here is a display of what else can be implemented with such a display system.";
        //        levelCompleted = true;
        //        completeLevelUI.SetActive(true);
        //    }
        //}
    }
}
