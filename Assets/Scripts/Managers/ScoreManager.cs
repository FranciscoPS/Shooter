using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentScore;
    int highScore;

    public static ScoreManager instance;

    void Start()
    {
        if (instance == null) instance = this;
        else { Destroy(this); }
        getHighScore();
    }

    private void OnDestroy()
    {
        setHighScore();
    }

    public void addScore(int score)
    {
        currentScore += score;
        UIManager.Instance.UpdateScoreText(currentScore);
        setHighScore();
    }

    public void getHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        UIManager.Instance.UpdateHighScoreText(highScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        UIManager.Instance.UpdateScoreText(currentScore);
    }

    public void setHighScore()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
