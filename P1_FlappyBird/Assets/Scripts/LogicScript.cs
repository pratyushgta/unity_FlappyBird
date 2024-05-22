using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int player_score;
    public Text player_score_text;
    public GameObject gameOverObject;
    public bool isGameActive = false;

    [ContextMenu("IncreaseScore")]
    public void addScore(int scoreToAdd)
    {
        player_score = player_score+scoreToAdd;
        player_score_text.text = player_score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverObject.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.CreateScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
