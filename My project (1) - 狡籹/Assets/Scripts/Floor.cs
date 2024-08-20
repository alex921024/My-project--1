using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zBound;
    [SerializeField] private float zOffset;
    private void Update()
    {
        if (gameManager.IsGameOver) return;
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        if(transform.position.z <= zBound )
        {
            transform.position += new Vector3(0, 0, zOffset);
        }
    }
}
