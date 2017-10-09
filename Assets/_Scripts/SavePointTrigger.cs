using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointTrigger : MonoBehaviour {

    private Transform spawnPoint;
    private Transform flares;
    private GameManager gameManager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Savepoint!");
        //gameManager.SpawnPoint = transform.parent.Find("SpawnPoint").transform; //simpler
        gameManager.SpawnPoint = spawnPoint;
        flares.gameObject.SetActive(true);
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnPoint = transform.parent.Find("SpawnPoint").transform;
        flares = transform.parent.Find("Flares").transform;
    }
}
