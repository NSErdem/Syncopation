using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameMenu : MonoBehaviour
{

    public GameObject inGameScreen, pauseScreen;
  


    public void PauseButton()
    {
        Time.timeScale=0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void unPauseButton()
    {
        Time.timeScale=1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void rePlayButton()
    {
        Time.timeScale=1;
        if(SceneManager.GetActiveScene().name=="GameLevel")
        {
        SceneManager.LoadScene(1);
        }
                if(SceneManager.GetActiveScene().name=="GameLevel2")
                {
                            SceneManager.LoadScene(2);

                }
                if(SceneManager.GetActiveScene().name=="GameLevelHard")
                {
                            SceneManager.LoadScene(3);

                }
                if(SceneManager.GetActiveScene().name=="GameLevelHard2")
                {
                            SceneManager.LoadScene(4);

                }

    }

    public void mainMenuButton()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(0); 

    }

    public void restartButton()
    {
        Time.timeScale=1;
        if(SceneManager.GetActiveScene().name=="GameLevel")
        {
        SceneManager.LoadScene(1);
        }
        if(SceneManager.GetActiveScene().name=="GameLevel2")
                {
                            SceneManager.LoadScene(2);
                }
                if(SceneManager.GetActiveScene().name=="GameLevelHard")
                {
                            SceneManager.LoadScene(3);

                }
                if(SceneManager.GetActiveScene().name=="GameLevelHard2")
                {
                            SceneManager.LoadScene(4);

                }
    } 

}
