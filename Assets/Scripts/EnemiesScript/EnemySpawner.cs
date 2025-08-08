
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{
    public GameObject[] Enemies;
    public Transform Spawn;
    

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += ManejarCambioEstado;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= ManejarCambioEstado;
    }

    private void ManejarCambioEstado(GameManager.GameState nuevoEstado)
    {
        if (nuevoEstado == GameManager.GameState.Playing)
        {
            GameManager.Instance.canSpawn = true;
            StartCoroutine(SpawnLoop());
        }
        else
        {
            GameManager.Instance.canSpawn = false;
            StopAllCoroutines();
        }
    }

    public void Spawner()
    {
        GameObject enemigo = Enemies[Random.Range(0, Enemies.Length)];
        Instantiate(enemigo, Spawn.position, Quaternion.identity);
    }

    private IEnumerator SpawnLoop()
    {
        while (GameManager.Instance.canSpawn)
        {
            float spawnInterval = Random.Range(1,5);
            yield return new WaitForSeconds(spawnInterval);
            Spawner();
        }
    }
}