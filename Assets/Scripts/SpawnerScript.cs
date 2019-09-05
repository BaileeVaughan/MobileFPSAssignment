using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float spawnRadius = 5f;
    public GameObject[] prefabs;
    public float spawnRate = 1f;
    public float spawnFactor = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, spawnRadius);
    }

    void Update()
    {
        HandleSpawn();
    }

    void HandleSpawn()
    {
        spawnFactor += Time.deltaTime;
        if (spawnFactor >= spawnRate)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            Spawn(prefabs[randomIndex]);
            spawnFactor = 0;
        }
    }

    void Spawn(GameObject gO)
    {
        GameObject newObject = Instantiate(gO);
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        newObject.transform.position = transform.position + randomPoint;
    }
}
