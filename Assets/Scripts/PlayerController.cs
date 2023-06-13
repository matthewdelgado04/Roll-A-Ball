using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody rb;
    private int pickupCount;



    // Start is called before the first frame update
    void Start()
    //get the amount of pickups in our scene in order to input amount 

    {
        pickupCount = GameObject.FindGameObjectsWithTag("PickUp").Length;
        //print the amount of pickups   
        print("Pickup Count: " + pickupCount);
        //run the check pickups function 
        CheckPickups();

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movment * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")

        {
            Destroy(other.gameObject);
            //decrement the pickup count
            pickupCount -= 1;
            //run the check pickups function 
            CheckPickups();
        }
    }
    void CheckPickups()
    {
        //print the amount of pickups left in our screen
        print("Pickup Count " + pickupCount);

        if (pickupCount == 0)
        {
            print("Wee Wooo you did it :P");
        }
    }
}


