using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject obstacle;

    public float maxTime;
    float timer;

    public float maxY;
    public float minY;
    float randY;
    // Use this for initialization
    void Start () {
        //InstantiateObstacles();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameOver == false && GameManager.gameStarted==true)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                InstantiateObstacles();
                timer = 0;
            }
        }        
	}
    public void InstantiateObstacles() {
        randY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randY);
    }
}
