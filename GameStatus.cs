using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public GameObject levelEndPanel;
    public Vector3 player_loc;
    public Vector3 end_loc;
    public GameObject Traps;
        public GameObject Traps2;
            public GameObject Traps3;
public GameObject Traps4;


 void Awake() {
                StartCoroutine(ActivateTraps());
                StartCoroutine(ActivateTraps2());
                StartCoroutine(ActivateTraps3());
                StartCoroutine(ActivateTraps4());


    }
    void Start()
    {
       end_loc= new Vector3(291.0847f, -1.101f, 0f);
                StartCoroutine(ActivateTraps());
                StartCoroutine(ActivateTraps2());
                StartCoroutine(ActivateTraps3());    
                StartCoroutine(ActivateTraps3());
}

    void Update()
    {
        player_loc= GameObject.Find("Player").transform.position;
        endOfLevel();
    }
        
    public void endOfLevel()
    {
        if(player_loc.x >= end_loc.x)
        {
            levelEndPanel.SetActive(true);
            Time.timeScale=0;
          }
        else
        {
            levelEndPanel.SetActive(false);
            Time.timeScale=1;

            
        }
    }
IEnumerator ActivateTraps()
    
{      
    yield return new WaitForSeconds(3f);
        Traps.SetActive(true);
  StartCoroutine(ActivateTraps());
}
IEnumerator ActivateTraps2()
    
{      
    yield return new WaitForSeconds(3f);
        Traps2.SetActive(true);
  StartCoroutine(ActivateTraps2());
}
IEnumerator ActivateTraps3()
    
{      
    yield return new WaitForSeconds(3f);
        Traps3.SetActive(true);
  StartCoroutine(ActivateTraps3());
}
IEnumerator ActivateTraps4()
    
{      
    yield return new WaitForSeconds(8f);
        Traps4.SetActive(true);
  StartCoroutine(ActivateTraps4());
}
    public void continueButton()
    {
        Time.timeScale=1;
       if(SceneManager.GetActiveScene().name=="GameLevel")
        {
        SceneManager.LoadScene(2);
        }
        if(SceneManager.GetActiveScene().name=="GameLevel2")
                {
                            SceneManager.LoadScene(0);
                }
        if(SceneManager.GetActiveScene().name=="GameLevelHard")
                {
                            SceneManager.LoadScene(4);
                }
                if(SceneManager.GetActiveScene().name=="GameLevelHard2")
                {
                            SceneManager.LoadScene(0);
                }
                
    }
     
}
