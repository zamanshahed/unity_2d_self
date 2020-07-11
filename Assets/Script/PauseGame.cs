using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject GetReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPausedGame()
    {
        if (GameManager.gamePaused == false)
        {
            Time.timeScale = 0;
            GetReady.SetActive(true);
            GameManager.gamePaused = true;
        }
        else
        {
            GetReady.SetActive(false);
            Time.timeScale = 1;
            GameManager.gamePaused = false;
        }
    }
}
