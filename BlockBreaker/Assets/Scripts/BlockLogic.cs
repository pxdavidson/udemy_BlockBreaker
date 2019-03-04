using System;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{ 
    // Define Variables
    [SerializeField] AudioClip blockSFX;
    [SerializeField] int blockScore = 10;

    // Cache
    LevelManager levelManager;
    ScoreLogic scoreLogic;

    // Start is called before the first frame update
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        scoreLogic = FindObjectOfType<ScoreLogic>();
        levelManager.IncrementBlocksRemaining();
    }

    // Detect collision with Colliders
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayBlockSFX();
        DestroyBlock();
    }

    // Plays the blockSFX. Triggered by collision
    private void PlayBlockSFX()
    {
        AudioSource.PlayClipAtPoint(blockSFX, Camera.main.transform.position);
    }

    // Destroy GameObject
    private void DestroyBlock()
    {
        scoreLogic.UpdateScoreBoard(blockScore);
        levelManager.BlockDestroyed();
        Destroy(gameObject);
    }
}
