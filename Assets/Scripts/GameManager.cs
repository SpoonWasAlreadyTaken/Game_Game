using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameVictoryUI;

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        gameVictoryUI.SetActive(false);
    }


    public void gameVictory()
    {
        gameVictoryUI.SetActive(true);
    }


    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarted");
    }

}
