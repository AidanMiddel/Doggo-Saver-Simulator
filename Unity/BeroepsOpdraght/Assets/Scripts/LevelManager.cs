using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { set; get; }

    private int hitpoint = 3;
    private int score;

    public Transform spawnPoints;
    public Transform playerTransform;

    //before private void start()
    private void Awake()
    {
        
        Instance = this;
    }

    private void Update()
    {
        score++;
        if (playerTransform.position.y < -10)
        {
            playerTransform.position = spawnPoints.position;
            hitpoint--;
            if (hitpoint <= 0)
            {
                Debug.Log("You have Failed");
                Debug.Log(score);
            }

        } 
    }


    public void Win()
    {
        Debug.Log("You have won");
    }
}
