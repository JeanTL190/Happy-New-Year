﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI = null;
    [SerializeField] private GameObject menuIniciar = null;
    public static bool paused = false;
    public static int dificuldade = 1;

    public void SetDificuldade(int d)
    {
        dificuldade = d;
    }

    public void LoadScene(string scene)
    {
        //What's diference bitween SceneManager.LoadScene() and Application.LoadLevel(); 
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
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

    public void ActivateSomeMenu(GameObject other)
    {
        menuIniciar.SetActive(false);
        other.SetActive(true);
    }

    public void Return(GameObject other)
    {
        menuIniciar.SetActive(true);
        other.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlayerBehavior.dead && pauseMenuUI != null)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
