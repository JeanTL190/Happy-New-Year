using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksBehaviour : MonoBehaviour
{

    Vector2 v, v2;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float speed = 1.5f; 
    float distance;
    void Start()
    {
       
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        v = transform.position;
        v2 = new Vector2(Random.Range(-6, 6), Random.Range(-3.4f, 4.7f));
        
        transform.eulerAngles = new Vector3(0,0, Mathf.Rad2Deg * Mathf.Atan2((v2 - v).y, (v2 - v).x)-90);
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, v2);
        if (distance > 0)
            transform.position = Vector2.Lerp(transform.position, v2, Time.deltaTime* speed / distance);
        if((Vector2)transform.position == v2)
        {
            anim.SetTrigger("Explode");
        }
        
    }
}
