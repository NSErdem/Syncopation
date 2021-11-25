using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject ControlsPanel;
    public GameObject infoPanel;

    public GameObject LevelsPanel;



    
    bool isPanelActive;

void Start()
{
    isPanelActive=false;
}
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }
    

    public void controlsButton()
    {
        if(!isPanelActive)
        {
            ControlsPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        }
        else
        {
            ControlsPanel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        }
            isPanelActive=!isPanelActive;
    }


public void infoButton()
    {
        if(!isPanelActive)
        {
            infoPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        }
        else
        {
            infoPanel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        }
            isPanelActive=!isPanelActive;
    }

public void levelsButton()
    {
        if(!isPanelActive)
        {
            LevelsPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        }
        else
        {
            LevelsPanel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        }
            isPanelActive=!isPanelActive;
    }


    public void quitButton()
    {
        Application.Quit();    
    }

    public void level1140Button()
    {
        SceneManager.LoadScene(3);
    }

    public void level2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void level2140Button()
    {
        SceneManager.LoadScene(4);
    }
}
