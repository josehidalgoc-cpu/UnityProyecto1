using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float minTime = 1f;
    public float maxTime = 2f;

    void Start()
    {
        StartCoroutine(SpawnCoRutine(0));
    }

    // Cambiamos 'StartCoroutine' por 'IEnumerator SpawnCoRutine'
    IEnumerator SpawnCoRutine(float waiTime)
    {
        yield return new WaitForSeconds(waiTime);
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
        StartCoroutine(SpawnCoRutine(Random.Range(minTime, maxTime)));
    }

    void Update()
    {
        
    }
}