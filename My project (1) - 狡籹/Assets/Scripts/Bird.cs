using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody birdRigidbody;
    [SerializeField] private Animator birdAnimator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip addSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private GameObject crashSmoke;
    [SerializeField] private float jumpForce;
    private void Update()
    {
        if (gameManager.IsGameOver) return;  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            birdRigidbody.velocity = Vector3.up*jumpForce;
        }
        if (birdRigidbody.velocity.y > 0)
        {
            birdAnimator.SetBool("isFly", true);
            birdAnimator.SetBool("isFall", false);
        }
        else
        {
            birdAnimator.SetBool("isFly", false);
            birdAnimator.SetBool("isFall", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tube"))
        {
            gameManager.AddScore();
            audioSource.PlayOneShot(addSound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameManager.SetGameOver();
        audioSource.PlayOneShot(crashSound);
        Instantiate(crashSmoke,transform.position, Quaternion.identity);
        birdAnimator.SetBool("isFly", false);
        birdAnimator.SetBool("isFall", true);
    }
}
