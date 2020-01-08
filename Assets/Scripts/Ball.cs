using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 1f;
    [SerializeField] float yPush = 14.5f;
    [SerializeField] AudioClip[] ballSounds;

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached Component Reference
    AudioSource myAudioSource;

    void Start()
    {
        paddleToBallVector  = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted == false)
        {
            LockBallWithPaddle();
            LaunchBallOnMouseClick();
        }
        
       
    }

    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallWithPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myAudioSource.PlayOneShot(clip);
        }
        
    }
}
