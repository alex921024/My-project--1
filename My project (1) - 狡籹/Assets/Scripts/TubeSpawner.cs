using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Tube tubePrefab;
    [SerializeField] protected float spawnMaxY;
    [SerializeField] protected float spawnMinY;
    [SerializeField] protected float spawnTime;
    float timer = 0f;
    private void Update()
    {
        if (gameManager.IsGameOver) return;
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer = 0f;
            SpawnTube();
        }
    }
    private void SpawnTube()
    {
        Vector3 spawnPos = new Vector3(transform.position.x,Random.Range(spawnMinY,spawnMaxY),transform.position.z);
        Instantiate(tubePrefab,spawnPos,Quaternion.identity);
    }
}
