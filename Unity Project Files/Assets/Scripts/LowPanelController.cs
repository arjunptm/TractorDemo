using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LowPanelController : MonoBehaviour
{
    public Text distance;
    public Text velocity;
    public GameObject bucket;
    public GameObject obstacle;
    public GameObject ground;
    public GameObject chassis;
    public Sprite bucket100;
    private Vector3 initPos;




    public Image bucketImage;

    // Start is called before the first frame update
    void Start()
    {
        //weatherImage.sprite = sunny;
        //weatherText.text = "It is sunny, the dirt might be dry and fall off.";
        //initPos = new Vector3(bucketImage.transform.position.x, transform.position.y, transform.position.z);
        initPos = bucketImage.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distVal =  Mathf.Abs(bucket.transform.position.z - obstacle.transform.position.z) - (float)1;
        distance.text = "|<-" + distVal.ToString("F2") + "m ->|";

        //float heightVal = Mathf.Abs(bucket.transform.position.y - ground.transform.position.y) - (float)1.01;
        float velocity = chassis.GetComponent<Rigidbody>().velocity.magnitude;
        this.velocity.text = velocity.ToString("F2") + "m/s";

        

        bucketImage.transform.position = new Vector3 (bucketImage.transform.position.x, initPos.y + bucket.GetComponent<BucketMovement>().elevation.y/10, bucketImage.transform.position.z);
        bucketImage.sprite = bucket100;
        

        
    }
}
    