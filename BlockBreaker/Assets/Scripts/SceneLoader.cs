using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Loads next scene in build index
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene+1);
    }

    // Loads first scene in build index
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    // Quits application
    public void QuitApplication()
    {
        Application.Quit();
    }
}
