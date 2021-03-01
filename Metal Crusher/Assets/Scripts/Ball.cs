using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parameters
    [SerializeField] Paddle paddle1; // to get the position data of the paddle
    [SerializeField] float pushX = 2f;
    [SerializeField] float pushY = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted;

    //Cached Component References
    AudioSource myAudioSource; // an audio source

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position; // the ball's position - the paddle's position
        hasStarted = false;
        myAudioSource = GetComponent<AudioSource>(); // knows exactly which component it is.  Since it's attached to the ball
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) // once it clicks, the ball won't lock to the ball and we won't launch it again
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY); // declare a velocity
            Debug.Log(hasStarted);
        }
    }

    private void LockBallToPaddle()
    {        
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); // tells where the position of the paddle is;
            transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) 
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)]; // the clip is gonna be random between any of our sounds, each time we hit a collision
            myAudioSource.PlayOneShot(clip); // Get the Audio Source component of the ball.  Play the clip in its entirety without interruptions.
                                                            // Every collision we're going to play a different sounds    
        }
    }
}
