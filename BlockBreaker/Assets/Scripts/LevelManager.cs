using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Define variables
    int blocksRemaining;

    // Cache
    SceneLoader sceneLoader;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Increment the block counter by 1
    public void IncrementBlocksRemaining()
    {
        blocksRemaining++;
    }

    // Adjust the count after blocks have been destroyed
    public void BlockDestroyed()
    {
        blocksRemaining = (blocksRemaining - 1);
        Debug.Log(blocksRemaining);
        WinCondition();
    }

    // Check win condition
    private void WinCondition()
    {
        if (blocksRemaining <= 0)
        {
            sceneLoader.LoadNextScene();
        }
        else
        {
            // Do Nothing
        }
    }
}
