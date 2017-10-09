using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Player's Actor Prefab
    [SerializeField] private GameObject playerPrefab;
    //Spawn point (in-level)
    [SerializeField] private Transform spawnPoint;
    //Camera's Follow Script
    [SerializeField] CameraSmoothFollow followingCamera;
    //Wait until respawn after death
    [SerializeField] private float waitUntilRespawn = 1.0f;
    //TODO: need to be created only within this manager!
    [SerializeField] private GUIManager guiManagerInstance;


    //Holding current player Actor
    private GameObject currentPlayer;
    
    private int livesAmount = 0;

    public Transform SpawnPoint
    {
        get { return spawnPoint; }
        set { spawnPoint = value; }        
    }

    public int LivesAmount
    {
        set
        {
            if (value > 0)
            {
                livesAmount = value;
                guiManagerInstance.Lives = livesAmount;
            }
            else Debug.LogError("Lives cannot be zero or less! Got " + value.ToString(), this);
        }
    }

    // Use this for initialization
	void Start ()
    {
        followingCamera = FindObjectOfType<CameraSmoothFollow>();
    }
	
	//Player died somehow
    //Use by death triggers
    public void PlayerDeath()
    {
        //color "death" animation
        currentPlayer.GetComponent<Animator>().enabled = true;
        
        //renderer.material.color = new Color(1.0f, 1.0f, 1.0f);        
        //suspended execution of respawn
        //yield return new WaitForSeconds(waitUntilRespawn);
        Invoke("Restart", waitUntilRespawn);
    }



    //Used to start the game from the main menu
    public void GameStart()
    {
        RespawnPlayer(spawnPoint);
        livesAmount = 5;
        guiManagerInstance.Lives = livesAmount;
        guiManagerInstance.GameStart();
    }

    //Use to restart/respawn
    public void Restart()
    {
        DestroyPlayer();
        if (livesAmount > 1)
        {
            livesAmount--;
            guiManagerInstance.Lives = livesAmount;
            RespawnPlayer(spawnPoint);
        }
        else GameOver();
    }

    void GameOver()
    {
        guiManagerInstance.GameOverScreenShow();

    }

    public void GameWin()
    {
        guiManagerInstance.GameWinScreenShow();
    }

    //respawn player prefab in desired position
    void RespawnPlayer(Transform spawnPosition)
    {
        currentPlayer = Instantiate(playerPrefab);
        currentPlayer.transform.position = spawnPosition.position;
        followingCamera.target = currentPlayer.transform;
    }

    void DestroyPlayer()
    {
        followingCamera.target = null;
        Destroy(currentPlayer);
    }

    

}
