using System;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{ 
    // Define Variables
    [SerializeField] AudioClip blockSFX;

    // detect Collisio with Colliders
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayBlockSFX();
        Destroy();
    }

    // Plays the blockSFX. Triggered by collision
    private void PlayBlockSFX()
    {
        AudioSource.PlayClipAtPoint(blockSFX, Camera.main.transform.position);
    }

    // Destroy GameObject
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
