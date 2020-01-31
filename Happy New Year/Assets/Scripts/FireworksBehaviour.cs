using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksBehaviour : MonoBehaviour
{

    private Vector2 v, v2;
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D collider;
    private PlayerBehavior player;
    private AudioSource audio;

    private float distance;
    private bool freezin = false;
    private bool explode = false;

    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float gravity = 1f;
   
    void Start()
    {
       
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        audio = this.gameObject.GetComponent<AudioSource>();
        v = this.transform.position;
        v2 = new Vector2(Random.Range(-6, 6), Random.Range(-1.5f, 4.7f));
        collider = this.gameObject.GetComponent<Collider2D>();
        player = FindObjectOfType<PlayerBehavior>();

        this.transform.eulerAngles = new Vector3(0,0, Mathf.Rad2Deg * Mathf.Atan2((v2 - v).y, (v2 - v).x)-90);
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }

    public void Freeze()
    {
        freezin = true;
        rb.gravityScale = gravity;
        anim.SetTrigger("Freeze");

    }

    public bool GetFreezin()
    {
        return freezin;
    }

    public void TakeDamage()
    {
        if(player!=null)
            player.TookDamage();
    }

    void Update()
    {
        distance = Vector2.Distance(this.transform.position, v2);
        if (distance > 0 && !freezin)
            this.transform.position = Vector2.Lerp(this.transform.position, v2, Time.deltaTime* speed / distance);
        if((Vector2)transform.position == v2 && !explode)
        {
            anim.SetTrigger("Explode");
            audio.Play();
            explode = true;
            collider.enabled = false;
        }
        if(transform.position.y<-6)
        {
            Destruir();
        }
        
    }
}
