using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoproCongelante : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FireworksBehaviour fireworks = other.GetComponent<FireworksBehaviour>();
        if (fireworks != null)
        {
            fireworks.Freeze();
        }

    }
}
