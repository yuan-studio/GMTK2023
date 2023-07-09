using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playBtn : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject TutorialMenu;


    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void tutorialStart()
    {
        MainMenu.SetActive(false);
        TutorialMenu.SetActive(true);
    }

    public void quitTutorial()
    {
        MainMenu.SetActive(true);
        TutorialMenu.SetActive(false);
    }

    public void quitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
