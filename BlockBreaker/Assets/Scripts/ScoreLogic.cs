using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    // Define variables
    Text scoreText;
    int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = currentScore.ToString();
    }

    // Update score
     public void UpdateScoreBoard(int scoreIncrease)
    {
        currentScore = currentScore + scoreIncrease;
        scoreText.text = currentScore.ToString();
    }
}
