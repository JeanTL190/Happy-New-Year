using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite[(int)Random.Range(0, sprite.Length)];
    }
}
