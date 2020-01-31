using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int dificuldade=0;
    private PlayerBehavior player;

    [SerializeField] private Text health;
    [SerializeField] private Text score;
    [SerializeField] private Text highScore;
    [SerializeField] private Text newHighScore;
    [SerializeField] private Text yourScore;
    [SerializeField] private Text dificuldadeText;
    [SerializeField] private Text easyName;
    [SerializeField] private Text easyValue;
    [SerializeField] private Text normalName;
    [SerializeField] private Text normalValue;
    [SerializeField] private Text hardName;
    [SerializeField] private Text hardValue;
    [SerializeField] private Text impossibleName;
    [SerializeField] private Text impossibleValue;
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private GameObject panel;
    [SerializeField] private InputField inp;

    void Start()
    {
        Cursor.visible = false;
        player = FindObjectOfType<PlayerBehavior>();
        dificuldade = MenuFunctions.dificuldade;
        GetHighScore();
    }

    private void GetHighScore()
    {
        if(dificuldade == 1)
            highScore.text = PlayerPrefs.GetInt("HighScoreEasy", 0).ToString();
        else if (dificuldade == 2)
            highScore.text = PlayerPrefs.GetInt("HighScoreNormal", 0).ToString();
        else if (dificuldade == 3)
            highScore.text = PlayerPrefs.GetInt("HighScoreHard", 0).ToString();
        else
            highScore.text = PlayerPrefs.GetInt("HighScoreImpossible", 0).ToString();
    }

    private void SetHighScore()
    {
        int s = player.ScoreValue();
        if (dificuldade == 1)
        {
            if (s > PlayerPrefs.GetInt("HighScoreEasy", 0))
            {
                PlayerPrefs.SetInt("HighScoreEasy", s);
                highScore.text = s.ToString();
            }
        }
           
        else if (dificuldade == 2)
        {
            if (s > PlayerPrefs.GetInt("HighScoreNormal", 0))
            {
                PlayerPrefs.SetInt("HighScoreNormal", s);
                highScore.text = s.ToString();
            }
        }
        else if (dificuldade == 3)
        {
            if (s > PlayerPrefs.GetInt("HighScoreHard", 0))
            {
                PlayerPrefs.SetInt("HighScoreHard", s);
                highScore.text = s.ToString();
            }
        }
        else
        {
            if (s > PlayerPrefs.GetInt("HighScoreImpossible", 0))
            {
                PlayerPrefs.SetInt("HighScoreImpossible", s);
                highScore.text = s.ToString();
            }
        }
    }

    private void PlayerDead()
    {
        if(player.GetVida()==0)
        {
            Time.timeScale = 0f;
            MenuFunctions.paused = true;
            PlayerBehavior.dead = true;
            Cursor.visible = true;
            int s = player.ScoreValue();
            if (dificuldade == 1)
            {
                if (s == PlayerPrefs.GetInt("HighScoreEasy", 0))
                {
                    highScorePanel.SetActive(true);
                    newHighScore.text = highScore.text;
                }
                else
                    ButSave();
            }

            else if (dificuldade == 2)
            {
                if (s == PlayerPrefs.GetInt("HighScoreNormal", 0))
                {
                    highScorePanel.SetActive(true);
                    newHighScore.text = highScore.text;
                }
                else
                    ButSave();
            }
            else if (dificuldade == 3)
            {
                if (s == PlayerPrefs.GetInt("HighScoreHard", 0))
                {
                    highScorePanel.SetActive(true);
                    newHighScore.text = highScore.text;
                }
                else
                    ButSave();
            }
            else
            {
                if (s == PlayerPrefs.GetInt("HighScoreImpossible", 0))
                {

                    highScorePanel.SetActive(true);
                    newHighScore.text = highScore.text;
                }
                else
                    ButSave();
            }
        }
    }

    public void EndEdit()
    {
        if (dificuldade == 1)
           PlayerPrefs.SetString("HighScoreEasyName", inp.text);
        else if (dificuldade == 2)
           PlayerPrefs.SetString("HighScoreNormalName", inp.text);
        else if (dificuldade == 3)
            PlayerPrefs.SetString("HighScoreHardName", inp.text);
        else
            PlayerPrefs.SetString("HighScoreImpossibleName", inp.text);
    }

    public void ButSave()
    {
        highScorePanel.SetActive(false);
        panel.SetActive(true);
        yourScore.text = score.text;
        if (dificuldade == 1)
            dificuldadeText.text = "Easy";
        else if (dificuldade == 2)
            dificuldadeText.text = "Normal";
        else if (dificuldade == 3)
            dificuldadeText.text = "Hard";
        else
            dificuldadeText.text = "Impossible";

        easyName.text = PlayerPrefs.GetString("HighScoreEasyName", "");
        easyValue.text = PlayerPrefs.GetInt("HighScoreEasy", 0).ToString();
        normalName.text = PlayerPrefs.GetString("HighScoreNormalName", "");
        normalValue.text = PlayerPrefs.GetInt("HighScoreNormal", 0).ToString();
        hardName.text = PlayerPrefs.GetString("HighScoreHardName", "");
        hardValue.text = PlayerPrefs.GetInt("HighScoreHard", 0).ToString();
        impossibleName.text = PlayerPrefs.GetString("HighScoreImpossibleName", "");
        impossibleValue.text = PlayerPrefs.GetInt("HighScoreImpossible", 0).ToString();

    }

    public int GetDificuldade()
    {
        return dificuldade;
    }

    void Update()
    {
        health.text = player.GetVida().ToString();
        score.text = player.ScoreValue().ToString();
        SetHighScore();
        PlayerDead();
    }
}
