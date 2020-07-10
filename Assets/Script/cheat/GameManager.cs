using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool gameOver;
    public static bool gameStarted;
    public static bool gamePaused;

    public GameObject ScoreTxt;
    public GameObject GameOverUI;
    public GameObject GetReadyImg;
    public GameObject pauseBtn;
    public GameObject menuBtn;

    public static Vector2 bottomLeft;
    // Use this for initialization

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }

    void Start () {
        gameOver = false;
        gameStarted = false;
        gamePaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameHasStarted()
    {
        gameStarted = true;
        ScoreTxt.SetActive(true);
        GetReadyImg.SetActive(false);
        pauseBtn.SetActive(true);
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverUI.SetActive(true);
        ScoreTxt.SetActive(false);
        pauseBtn.SetActive(false);
    }
    public void OkBtnPressed()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void OnMenuBtnPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
