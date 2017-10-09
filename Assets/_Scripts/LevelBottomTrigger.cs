using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBottomTrigger : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fallen to death");
        gameManager.PlayerDeath();
    }
    */
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Fallen to death");
        gameManager.PlayerDeath();
    }
}
