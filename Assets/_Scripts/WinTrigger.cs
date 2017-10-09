using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You won!");
        gameManager.GameWin();
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
}
