using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Vector3 posiMouse,movMouseAnte,mov;
    [SerializeField] float x, y;
    [SerializeField] float time=2f;
    [SerializeField] Animator anim; 
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine("VerificaPosiMouseAnte");
    }
    IEnumerator VerificaPosiMouseAnte()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            movMouseAnte = posiMouse;
        }
    }
    private void FixedUpdate()
    {
        mov = posiMouse- movMouseAnte;
        
        if(mov.normalized.y>0)
        {
            anim.SetInteger("Fly", 1);
        }
        else if(mov.normalized.y<0)
        {
            anim.SetInteger("Fly", -1);
        }
        else
        {
            anim.SetInteger("Fly", 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        posiMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;

        if (posiMouse.x > x)
        {
            if (posiMouse.y > y)
                transform.position = new Vector3(x, y);
            else if(posiMouse.y < -y)
                transform.position = new Vector3(x, -y);
            else
                transform.position = new Vector3(x, posiMouse.y);
        }
        else if(posiMouse.x < -x)
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
}
