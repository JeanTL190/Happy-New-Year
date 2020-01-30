using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    private static int dificuldade=0;

    public int GetDificuldade()
    {
        return dificuldade;
    }

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
}
