using UnityEngine;

public class BallLogic : MonoBehaviour
{
    // Define Variables
    [SerializeField] PlayerController paddle1;

    // States
    Vector3 ballVector;
    
    // Start is called before the first frame update
    void Start()
    {
        ballVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 paddlePos = paddle1.transform.position;
        Vector3 ballPos = paddlePos + ballVector;
        transform.position = ballPos;
    }
}
