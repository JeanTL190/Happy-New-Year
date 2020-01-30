﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Vector3 posiMouse,movMouseAnte,mov;
    private Animator anim;
    private int health;
    private GameManager gameManager;

    [SerializeField] private float x, y;
    [SerializeField] private float time=2f;
    

    void Start()
    {
        StartCoroutine("VerificaPosiMouseAnte");
        anim = this.gameObject.GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

    }
    
    private void DeterminaVida()
    {
        if (gameManager.GetDificuldade() == 1)
            health = 20;
        else if (gameManager.GetDificuldade() == 2)
            health = 10;
        else if (gameManager.GetDificuldade() == 3)
            health = 5;
        else
            health = 1;
    }

    public void TookDamage()
    {
        health--;
        if (health < 0)
            Debug.Log("YouLoose");
    }

    public int GetVida()
    {
        return health;
    }

    IEnumerator VerificaPosiMouseAnte()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            movMouseAnte = posiMouse;
        }
    }

    private void Movimentacao()
    {
        if (posiMouse.x > x)
        {
            if (posiMouse.y > y)
                transform.position = new Vector3(x, y);
            else if (posiMouse.y < -y)
                transform.position = new Vector3(x, -y);
            else
                transform.position = new Vector3(x, posiMouse.y);
        }
        else if (posiMouse.x < -x)
        {
            if (posiMouse.y > y)
                transform.position = new Vector3(-x, y);
            else if (posiMouse.y < -y)
                transform.position = new Vector3(-x, -y);
            else
                transform.position = new Vector3(-x, posiMouse.y);
        }
        else
        {
            if (posiMouse.y > y)
                transform.position = new Vector3(posiMouse.x, y);
            else if (posiMouse.y < -y)
                transform.position = new Vector3(posiMouse.x, -y);
            else
                transform.position = new Vector3(posiMouse.x, posiMouse.y);
        }

    }

    private void SoproCongelante()
    {
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("Attack");
    }

    private void FixedUpdate()
    {
        mov = posiMouse - movMouseAnte;

        if (mov.normalized.y > 0)
        {
            anim.SetInteger("Fly", 1);
        }
        else if (mov.normalized.y < 0)
        {
            anim.SetInteger("Fly", -1);
        }
        else
        {
            anim.SetInteger("Fly", 0);
        }
    }

    void Update()
    {
        posiMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        Movimentacao();
        SoproCongelante();
    }
}
