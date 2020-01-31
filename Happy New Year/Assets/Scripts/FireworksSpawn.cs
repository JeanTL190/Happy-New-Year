using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] fireworks;
    private AudioSource audio;
    void Start()
    {
        StartCoroutine("Spawn");
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f,1.5f));
            GameObject instancia = fireworks[Random.Range(0, fireworks.Length)];
            instancia.transform.position = this.transform.position;
            Instantiate(instancia);
            audio.Play();
        }
    }
}
