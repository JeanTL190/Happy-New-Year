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
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private InputField inp;

    void Start()
    {
        Cursor.visible = false;
        player = FindObjectOfType<PlayerBehavior>();
        dificuldade = MenuFunctions.dificuldade;
        GetHighScore();
        PlayerPrefs.DeleteAll();
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
            }

            else if (dificuldade == 2)
            {
                if (s == PlayerPrefs.GetInt("HighScoreNormal", 0))
                {
                    highScorePanel.SetActive(true);
                    newHighScore.text = highScore.text;
                }
            }
            else if (dificuldade == 3)
            {
                if (s == PlayerPrefs.GetInt("HighScoreHard", 0))
                {
                    highScorePanel.SetActive(true);
                    newHighScore.text = highScore.text;
                }
            }
            else
            {
                if (s == PlayerPrefs.GetInt("HighScoreImpossible", 0))
                {

                    highScorePanel.SetActive(true);
                    newHighScore.text = highScore.text;
                }
            }
        }
    }

    public void EndEdit()
    {
        if (dificuldade == 1)
           PlayerPrefs.SetString("HighScoreEasy", inp.text);
        else if (dificuldade == 2)
           PlayerPrefs.SetString("HighScoreNormal", inp.text);
        else if (dificuldade == 3)
            PlayerPrefs.SetString("HighScoreHard", inp.text);
        else
            PlayerPrefs.SetString("HighScoreImpossible", inp.text);
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
