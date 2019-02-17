using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // Detect collision with trigger object and load GameOver scren. NOTE: String is hard coded.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
    }
}
