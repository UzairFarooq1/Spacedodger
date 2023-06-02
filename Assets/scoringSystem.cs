using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoringSystem : MonoBehaviour
{
    private int score = 0;

    private int levelChange = 80;
    private int level = 1;

    private int highScore = 0;
    public Text scoreText;
    public Text Level;
    public TextMeshProUGUI highScoreText;
    public Transform playerTransform;

     private void Start()
    {
        // Load the high score from PlayerPrefs (or other storage mechanism)
        UpdateHighScoreText();
    }

    

    private void Update()
    {
        // Increase the score based on the player's forward movement
        float movement = Mathf.Abs(playerTransform.position.z);
        score = Mathf.FloorToInt(movement);

        // Update the score display
        scoreText.text = "Score: " + score.ToString();
        Level.text = "Level: " + level.ToString();
        CheckHighScore();
        CheckLevel();
        
    }

    void CheckLevel()
    {
        if(score>levelChange)
        {
            levelChange += 80;
            Level.text = "Level: " + level.ToString();
            level += 1;
        }
    }
    void CheckHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScoreText();
        }
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore",0)}";
    }

        // if (score > highScore)
        // {
        //     // Update the high score
        //     highScore = score;
        //     highScoreText.text = "High Score: " + highScore.ToString();

        //     // Save the high score to PlayerPrefs (or other storage mechanism)
        //     PlayerPrefs.SetInt("HighScore", highScore);
        //     PlayerPrefs.Save();
        // }
    
}