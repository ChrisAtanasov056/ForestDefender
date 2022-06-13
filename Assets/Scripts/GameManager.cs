using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;
    public GameObject moneyUI;
    public GameObject shopUI;
    public GameObject livesUI;

    void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        moneyUI.SetActive(false);
        livesUI.SetActive(false);
        shopUI.SetActive(false);
        Debug.Log("Game Over");
    }
}
