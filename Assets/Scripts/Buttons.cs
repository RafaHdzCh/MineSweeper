using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject boardGame;
    [SerializeField] Image mainMenuBackgroundImage;

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        boardGame.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackButton()
    {
        boardGame.SetActive(false);
        mainMenu.SetActive(true);
    }
}
