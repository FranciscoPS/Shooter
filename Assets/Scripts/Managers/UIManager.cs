using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject VictoryScreen;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HiScoreText;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
        }
    }
    

    private void Start()
    {
        EnableGameOver(false);
        EnableVictory(false);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScoreText(int hiscore)
    {
        HiScoreText.text = hiscore.ToString();
    }

    public void UpdateHPText(int hp)
    {
        hpText.text = hp.ToString();
    }

    public void EnableGameOver(bool enabled)
    {
        GameOverScreen.SetActive(enabled);
    }

    public void EnableVictory(bool enabled)
    {
        VictoryScreen.SetActive(enabled);
    }
}
