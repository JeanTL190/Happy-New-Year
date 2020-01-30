using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int dificuldade=0;
    private int health;
    private PlayerBehavior player;
    private MenuFunctions menu;
    public static bool paused = false;
    public GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

    }
    void Start()
    {
        player = FindObjectOfType<PlayerBehavior>();
        menu = FindObjectOfType<MenuFunctions>();
        dificuldade = menu.GetDificuldade();
        Cursor.visible = false;
    }

    public int GetDificuldade()
    {
        return dificuldade;
    }

    void Update()
    {
        health = player.GetVida();
    }
}
