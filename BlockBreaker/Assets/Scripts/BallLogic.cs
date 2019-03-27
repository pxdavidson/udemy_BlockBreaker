using UnityEngine;

public class BallLogic : MonoBehaviour
{
    // Define Variables
    [SerializeField] PlayerController paddle1;
    [SerializeField] float yLaunchVector = 10f;
    [SerializeField] AudioClip[] ballSFX;
    [SerializeField] float velocityRND;

    // Cache
    AudioSource audioSource;
    Rigidbody2D rigidBody2D;
    
    // States
    Vector3 ballVector;
    bool ballInPlay = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ballVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballInPlay)
        {
            LockBall();
            LaunchBall();
        }
    }

    // Add force to ball
    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float xLaunchVector = 0;
            rigidBody2D.velocity = new Vector2(xLaunchVector, yLaunchVector);
            ballInPlay = true;
        }
        else
        {
            // Do nothing
        } 
    }

    // Lock the ball to the paddle
    private void LockBall()
    {
        Vector3 paddlePos = paddle1.transform.position;
        Vector3 ballPos = paddlePos + ballVector;
        transform.position = ballPos;
    }

    // Detect collision with Collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayBallSFX();
        AddMovementNoise();
    }

    // Adds some random to vectors toavoid ball getting caught in a loop
    private void AddMovementNoise()
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, velocityRND), Random.Range(0f, velocityRND));
        rigidBody2D.velocity += velocityTweak;
    }

    // Play audio. Triggered when hitting Collider
    private void PlayBallSFX()
    {
        if (ballInPlay)
        {
            AudioClip clip = ballSFX[Random.Range(0, ballSFX.Length)];
            audioSource.PlayOneShot(clip);
        }
        else
        {
            // DO NOTHING
        }
    }
}
