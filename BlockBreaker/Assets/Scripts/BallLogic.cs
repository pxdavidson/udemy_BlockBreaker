using UnityEngine;

public class BallLogic : MonoBehaviour
{
    // Define Variables
    [SerializeField] PlayerController paddle1;
    [SerializeField] float yLaunchVector = 10f;
    [SerializeField] AudioClip[] ballSFX;

    // Cache
    AudioSource audioSource;
    
    // States
    Vector3 ballVector;
    bool ballInPlay = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ballVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
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
            float xLaunchVector = Random.Range(-2f, 2f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(xLaunchVector, yLaunchVector);
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
