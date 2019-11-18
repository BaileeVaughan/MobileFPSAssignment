using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float spawnRadius = 5f;
    public GameObject[] prefabs;
    public float spawnRate = 1f;
    public float spawnFactor = 0f;

    public bool spawn;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, spawnRadius);
    }

    void Update()
    {
            HandleSpawn();
    }

    public void HandleSpawn()
    {
        spawnFactor += Time.deltaTime;
        if (spawnFactor >= spawnRate)
        {
            RealSpawn();
            spawnFactor = 0;
        }
    }    

    public void RealSpawn()
    {
        if (spawn == true)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject newObject = Instantiate(prefabs[randomIndex]);
            Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
            newObject.transform.position = transform.position + randomPoint;
        }
    }
}
