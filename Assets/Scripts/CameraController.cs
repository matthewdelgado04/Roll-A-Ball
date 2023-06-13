using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    { //set the offset of the camera based on the player
        offset = transform.position - Player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the transformed potsition to be that of the players transformed position.   
        transform.position = Player.transform.position + offset;
    }
}
