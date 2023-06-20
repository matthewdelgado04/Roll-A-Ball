using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody rb;
    private int pickupCount;
    private Timer Timer;
    private bool gameOver;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject inGamePanel;
    public GameObject winPanel;
    public TMP_Text WinTime;


    // Start is called before the first frame update
    void Start()
    //get the amount of pickups in our scene in order to input amount 

    {
        pickupCount = GameObject.FindGameObjectsWithTag("PickUp").Length;
        //print the amount of pickups   
        print("Pickup Count: " + pickupCount); 
        //run the check pickups function 
        CheckPickups();
        //get the timer object 
        Timer = FindObjectOfType<Timer>();
        Timer.StartTimer();

        rb = GetComponent<Rigidbody>();
        //turn on our in game panel
        inGamePanel.SetActive(true);
       
        //turn off our win panel
        winPanel.SetActive(false);
    }
    private void Update()
    {
        timerText.text ="Time: " + Timer.GetTime().ToString("F2");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameOver == true)
        {
            return;
        }
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
        //display amount of pickups left in our screen
       
        scoreText.text = "Pickup Left " + pickupCount;

        if (pickupCount == 0)
        {
            WinGame();
        }
    }
    void WinGame()

    {    //set the game over to true
        gameOver = true;
       // Stop the timer
        Timer.StopTimer();
        //Turn on the win panel
        winPanel.SetActive(true);
        //Turn off the game panel
        inGamePanel.SetActive(false);
        //Display the timer on the win time text
        WinTime.text = "Your time was: " + Timer.GetTime().ToString("F2");
        print("Wee Wooo you did it :P. Your time was:" + Timer.currentTime);
        //set tge velocity of the rigidbody to zero
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;


    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
     }
    public void QuitGame()
    {
        Application.Quit();
    }
}


