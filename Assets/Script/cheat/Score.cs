using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    int highScore;
    Text scoreText;
    int score = 0;

    public Text panelScore;
    public Text PanelHighScore;

    public GameObject newImg;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();
        panelScore.text=score.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
        PanelHighScore.text = highScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PanelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            newImg.SetActive(true);
        }
    }
}
