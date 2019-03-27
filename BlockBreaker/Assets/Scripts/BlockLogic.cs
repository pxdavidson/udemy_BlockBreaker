using System;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{ 
    // Define Variables
    [SerializeField] AudioClip blockSFX;
    [SerializeField] GameObject blockVFX;
    [SerializeField] int blockScore = 10;
    [SerializeField] int blockHP = 3;
    int hitsTaken = 0;
    [SerializeField] Sprite[] hitSprites;

    // Cache
    LevelManager levelManager;
    ScoreLogic scoreLogic;

    // Start is called before the first frame update
    private void Start()
    {
        PopulateCache();
        CountBreakableBlocks();
    }

    // Populate the cache at start
    private void PopulateCache()
    {
        levelManager = FindObjectOfType<LevelManager>();
        scoreLogic = FindObjectOfType<ScoreLogic>();
    }

    // Count the breakable blocks
    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            levelManager.IncrementBlocksRemaining();
        }
        else
        {
            // Do nothing
        }
    }

    // Detect collision with Colliders
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayBlockSFX();
        if (tag == "Breakable")
        {
            hitsTaken++;
            CountHits();
        }
        else
        {
            // Do nothing
        }
    }

    // Count the hits taken
    private void CountHits()
    {
        if (hitsTaken == blockHP)
        {
            DestroyBlock();
        }
        else
        {
            int spriteIndex = hitsTaken - 1;
            if (hitSprites[spriteIndex] != null)
            {
                GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
            else
            {
                Debug.Log("Missing sprite on " + gameObject.name);
            }
        }
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
        PlayBlockVFX();
        Destroy(gameObject);
    }

    private void PlayBlockVFX()
    {
        GameObject blockVFXInstance = Instantiate(blockVFX, transform.position, transform.rotation);
        Destroy(blockVFXInstance, 1f);
    }
}
