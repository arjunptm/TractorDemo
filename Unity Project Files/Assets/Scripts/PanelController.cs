using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Text distance;
    public Text velocity;
    public GameObject bucket;
    public GameObject obstacle;
    public GameObject ground;
    public GameObject chassis;
    public Sprite bucket100;
    public Sprite bucket75;
    public Sprite bucket50;
    public Sprite bucket25;
    public Sprite bucket0;
    private Vector3 initPos;
    public GameObject warningSign;
    public GameObject dog;
    public Sprite sunny;
    public Sprite rainy;
    public Text weatherText;




    public Image bucketImage;
    public Image weatherImage;
    private int weightInBucket;
    //private bool weatherPressed;

    // Start is called before the first frame update
    void Start()
    {
        //weatherPressed = false;
        weightInBucket = 0;
        weatherImage.sprite = sunny;
        weatherText.text = "It is sunny, the dirt might be dry and fall off.";
        //initPos = new Vector3(bucketImage.transform.position.x, transform.position.y, transform.position.z);
        initPos = bucketImage.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distVal =  Mathf.Abs(bucket.transform.position.z - obstacle.transform.position.z) - (float)1.0;
        distance.text = "|<-" + distVal.ToString("F2") + "m ->|";

        //float heightVal = Mathf.Abs(bucket.transform.position.y - ground.transform.position.y) - (float)1.01;
        float velocity = chassis.GetComponent<Rigidbody>().velocity.magnitude;
        this.velocity.text = velocity.ToString("F2") + "m/s";

        if (Input.GetKey(KeyCode.Alpha0) || Input.GetAxis("SetWeight") > 0)
        {
            if (weightInBucket != 0) weightInBucket--;
            Debug.Log(weightInBucket);
        }
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetAxis("SetWeight") < 0)
        {
            if (weightInBucket < 40) weightInBucket++;

        }

        bucketImage.transform.position = new Vector3 (bucketImage.transform.position.x, initPos.y + bucket.GetComponent<BucketMovement>().elevation.y/10, bucketImage.transform.position.z);

        switch (weightInBucket/4)
        {
            case 0: bucketImage.sprite = bucket0; break;
            case 1: bucketImage.sprite = bucket25; break;
            case 2: bucketImage.sprite = bucket50; break;
            case 3: bucketImage.sprite = bucket75; break;
            case 4: bucketImage.sprite = bucket100; break;
        }

        if  (SceneManager.GetActiveScene().name == "03-ExtraInfo") {
            float dogDist = Vector3.Distance(bucket.transform.position, dog.transform.position);
            //Debug.Log(dogDist);
            if (dogDist <= 5)
            {
                warningSign.SetActive(true);
                GetComponent<AudioSource>().mute = false;
            }
            if (dogDist > 5)
            {
                warningSign.SetActive(false);
                GetComponent<AudioSource>().mute = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("SetWeather"))
        {
            //if (weatherPressed == false)
            //{
                if (weatherImage.sprite == rainy)
                {
                    weatherImage.sprite = sunny;
                    weatherText.text = "It is sunny, the dirt might be dry and fall off.";
                }
                else
                {
                    weatherImage.sprite = rainy;
                    weatherText.text = "It is rainy, the dirt might be wet and heavier than usual.";
                }
                //weatherPressed = true;
            //}
            //else
            //{
            //    //weatherPressed = false;
            //}
        }
        //if (Input.GetKey(KeyCode.Alpha3))
        //{
        //    weatherImage.sprite = rainy;
        //    weatherText.text = "It is rainy, the dirt might be wet and heavier than usual.";
        //}
    }
}
    