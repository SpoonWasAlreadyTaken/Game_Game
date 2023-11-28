using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Started");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void buttonTest()
    {
        Debug.Log("Works");
    }

}
