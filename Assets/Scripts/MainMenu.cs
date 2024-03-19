using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 public GameObject mainMenu;
 public GameObject OptionPannel;

 public void MainMenuScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }
 public void PlayGame()
    {
        Debug.Log("Play button is clicked");
        SceneManager.LoadSceneAsync(1);
    }

    public void OptionMenu()
    {
        Debug.Log("Option button is clicked");
        mainMenu.gameObject.SetActive(false);
        OptionPannel.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is closed...!!!");
    }

    public void Back()
    {
        mainMenu.gameObject.SetActive(true);
        OptionPannel.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Debug.Log("Game Restared");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
