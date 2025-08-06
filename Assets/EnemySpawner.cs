
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{
    public GameObject[] Enemies;
    public Transform Spawn;
    public float spawnInterval = 2f;
    public bool canSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canSpawn = true;
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void Spawner()
    {
        GameObject Enemigo = Enemies[Random.Range(0, Enemies.Length)];

        Instantiate(Enemigo, Spawn.position, Quaternion.identity);
    }

        private IEnumerator SpawnLoop()
    {
        while (canSpawn) 
        {
            yield return new WaitForSeconds(spawnInterval);
            Spawner();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
