using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    

    private bool gameHasEnded = false;
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;


    public Text scoreText;
    private int score = 0;

    public GameObject Player;

    

    public void GameEnded()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Debug.Log("Game over");
            Player.SetActive(false);
            gameOverUI.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }
    public void Restart()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("LevelMenu", 2f);
    }
    public void PlayerScored()
    {
        if (gameHasEnded)
        {
            return;
        }
        score++;
        scoreText.text = "Score:" + score.ToString();

    }
    public void LevelMenu()
    {
        SceneManager.LoadScene(1);
    }
}
