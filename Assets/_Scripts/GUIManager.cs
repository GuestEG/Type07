using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

    [SerializeField] private Transform gameOverScreen;
    [SerializeField] private Transform gameWinScreen;
    [SerializeField] private Transform gameScreen;
    [SerializeField] private Transform livesImage;

    private Transform livesAmountGroup;
    
    private int lives;
    //objects cache
    //private List<Transform> livesSpritesList;

    public int Lives
    {
        set
        {
            if (value > 0)
            {
                lives = value;
                Refresh();
            }
            else Debug.LogError("Lives cannot be zero or less! Got " + value.ToString(), this);
        }
    }

    void Refresh()
    {

        /*foreach (Transform sprite in livesSpritesList)
        {
            Destroy(sprite);            
        }
        livesSpritesList.Clear();
        */
        if (livesAmountGroup.childCount > 0)
        {
            foreach (Transform child in livesAmountGroup.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        //need something neat instead of this
        for (int i = 0; i < lives; i++)
        {
            Instantiate(livesImage, livesAmountGroup);
        }
    }

    public void GameOverScreenShow()
    {
        gameScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        gameWinScreen.gameObject.SetActive(false);
    }


    public void GameWinScreenShow()
    {
        gameScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        gameWinScreen.gameObject.SetActive(true);
    }
    

    public void GameStart()
    {
        gameScreen.gameObject.SetActive(true);
        Refresh();
    }

    // Use this for initialization
    void Start ()
    {
        livesAmountGroup = gameScreen.Find("LivesAmountGroup");
        gameOverScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(false);
        gameWinScreen.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
