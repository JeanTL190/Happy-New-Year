using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Sprite[] sprite;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite[(int)Random.Range(0, sprite.Length)];
    }
}
