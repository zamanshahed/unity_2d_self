using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
        Debug.Log("Game Over Triggered...");
    }
}
