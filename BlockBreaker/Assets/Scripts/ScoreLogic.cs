using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    // Define variables
    [SerializeField] Text scoreText;
    int currentScore = 0;

    // Count number of ScoreLogic scripts and destroy if multiple.
    private void Awake()
    {
        int countScoreLogic = FindObjectsOfType<ScoreLogic>().Length;
        if (countScoreLogic > 1)
        {
            DestroyGameObject();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DestroyGameObject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update score
     public void UpdateScoreBoard(int scoreIncrease)
    {
        currentScore = currentScore + scoreIncrease;
        scoreText.text = currentScore.ToString();
    }
}
