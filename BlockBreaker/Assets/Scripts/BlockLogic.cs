using System;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{ 
    // Define Variables
    [SerializeField] AudioClip blockSFX;

    // Cache
    LevelManager levelManager;

    // Start is called before the first frame update
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
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
        Destroy(gameObject);
        levelManager.BlockDestroyed();
    }
}
