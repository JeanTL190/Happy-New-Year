using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] fireworks;
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f,1.5f));
            GameObject instancia = fireworks[Random.Range(0, fireworks.Length)];
            instancia.transform.position = this.transform.position;
            Instantiate(instancia);
        }
    }
}
