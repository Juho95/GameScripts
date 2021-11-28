using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    public static float yPush = 10;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.1f;
    float realSpeed = yPush;

    // state
    Vector2 paddletoBallVector;
    bool hasStarted = false;
    Vector2 overMaxVelocity;
    Vector2 maxVelocity;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    private void Awake()
    {
        yPush *= PlayerPrefsController.GetDifficulty();
    }

    // Start is called before the first frame update
    void Start()
    {
        paddletoBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        
        Debug.Log("Difficulty setting currently is " + PlayerPrefsController.GetDifficulty());
        Debug.Log("Ball's yPush value is " + yPush);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBalltoPaddle();
            LaunchOnMouseClick();
        }


    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddletoBallVector + paddlePos;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[0];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }

    }
}

