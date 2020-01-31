using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoproCongelante : MonoBehaviour
{
    private PlayerBehavior player;
    private void Start()
    {
        player = FindObjectOfType<PlayerBehavior>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        FireworksBehaviour fireworks = other.GetComponent<FireworksBehaviour>();
        if (fireworks != null)
        {
            if (!fireworks.GetFreezin())
            {
                fireworks.Freeze();
                player.ScoreUP();
            }
        }
    }

}
