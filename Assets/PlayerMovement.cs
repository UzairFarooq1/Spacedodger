 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioCollision;
    public ParticleSystem explosionParticles;
    public ParticleSystem rightExhause;
    public ParticleSystem leftExhause;


    public float tiltAmount;
    Animator animator;

    private float originalRotation;


    public float speed = 25f; 
    public float minX = -5f; // Minimum X position
    public float maxX = 5f;
    // public int addedpoints = 1;
     // Maximum X position

    private bool canMove = false;
    // private bool collided = false;
    // private int score = 0;
    // private int currentScore = 0;
    // public Text scoreText;

    // public Text highScoreText;

    // private int highScore = 0;
    // public int pointsPerUnit = 10; // The number of points to award per unit of forward movement

    // private int currentPoints = 0; 
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        originalRotation = transform.rotation.z;
        animator = gameObject.GetComponent<Animator>();

        // UpdateScoreText();
        // highScore = PlayerPrefs.GetInt("HighScore", 0);
        // UpdateHighScoreText();

    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            animator.SetInteger("state",1);
        }
        if(Input.GetKeyDown(KeyCode.O)){
            animator.SetInteger("state",0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            canMove = true;
            animator.enabled= false;
        }

        if (!canMove)
        {
            return; // Exit the function if movement is not allowed
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        float moveInput = Input.GetAxis("Horizontal"); // Get the input for left and right movement

        // Calculate the new rotation angle based on the move input
        float newRotation = originalRotation - moveInput * tiltAmount;

        // Apply the new rotation to the spaceship
        transform.rotation = Quaternion.Euler(0f, 0f, newRotation);

        



        // Calculate the desired position based on the current position and input
        Vector3 desiredPosition = transform.position + movement * speed * Time.deltaTime;

        // Clamp the desired position within the X limits
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        // Move the object to the desired position
        transform.position = desiredPosition;

        // score = score + addedpoints;
        // UpdateScoreText();

        
        // float forwardMovement = speed * Time.deltaTime;


        // // Update points based on forward movement
        // int pointsToAdd = Mathf.RoundToInt( forwardMovement * pointsPerUnit);
        // currentPoints += pointsToAdd;

        // // You can display or use the points however you want
        // Debug.Log("Current Points: " + currentPoints);
    }
    void OnCollisionEnter(Collision collision)
    {
        
        // Check if the collision is with an obstacle (tagged as "Obstacle")
        if (collision.gameObject.CompareTag("Obstacle"))

            Instantiate(explosionParticles, collision.contacts[0].point, Quaternion.identity);
            rightExhause.gameObject.SetActive(false);
            leftExhause.gameObject.SetActive(false);
        {
            
            // collided = true;
            Die();
            
        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false; 
        Invoke(nameof(ReloadLevel), 1.4f);
        audioCollision.Play();
        

        // collided = false;
        // scoreText.text = "Score: " + currentScore;

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //collided = false;
    }
    // void UpdateScoreText()
    // {
    //     scoreText.text = "Score: " + score;
    //     currentScore = score;
    // }

    // public void UpdateHighScore(int newScore)
    // {
    //     if (newScore > highScore)
    //     {
    //         highScore = newScore;
    //         PlayerPrefs.SetInt("HighScore", highScore);
    //         UpdateHighScoreText();
    //     }
    // }

    // private void UpdateHighScoreText()
    // {
    //     highScoreText.text = "High Score: " + highScore.ToString();
        
    //     if(score > highScore)
    //     {
    //         highScore = score;
    //         highScoreText.text = "High Score: " + highScore.ToString();         
    //     }
        
    // }


    // void ResetObject()
    // {
    //     // Reset the object's position to the initial position
    //     transform.position = initialPosition;
    //     canMove = false;
    //     Update();
    // }
    
}
