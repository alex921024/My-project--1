using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zBound;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (gameManager.IsGameOver) return;
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (transform.position.z <= zBound )
        {
            Destroy(gameObject);
        }
    }
}
