using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gamePaused;
        
    public GameObject GameOverUI;
    public GameObject GetReady;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gamePaused = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerReady()
    {
        if (gamePaused == true)
        {
            Time.timeScale = 0;
            GetReady.SetActive(true);
            gamePaused = false;
        }
        else
        {
            Time.timeScale = 1;
            GetReady.SetActive(false);
            gamePaused = true;
        }
        
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
        //Debug.Log("Game Over Triggered...");
    }
}
