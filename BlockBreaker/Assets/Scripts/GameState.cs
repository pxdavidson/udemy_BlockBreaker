using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Declare variables
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] bool autoPlayEnabled = false;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlayEnabled;
    }
}
