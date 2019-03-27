using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Define Variables
    [SerializeField] int wolrdUnitScreenSize = 16;
    [SerializeField] float paddlePosXMin = 1f;
    [SerializeField] float paddlePosXMax = 15f;

    // Cache
    GameState gameState;
    BallLogic ballLogic;

    // Called when the game starts
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        ballLogic = FindObjectOfType<BallLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        PaddleControl();
    }

    // Moves paddle based on location of the mouse
    private void PaddleControl()
    {
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        paddlePos.x = Mathf.Clamp(GetXPos(), paddlePosXMin, paddlePosXMax);
        transform.position = paddlePos;
    }

    // Sets XPos based on either ball position for autoplay or mouse pos for player
    public float GetXPos()
    {
        if (gameState.IsAutoPlayEnabled())
        {
            return ballLogic.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * wolrdUnitScreenSize);
        }
    }
}
