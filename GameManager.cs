using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
   public AudioSource theMusic;
   public AudioSource theMusic2;
    public AudioSource theMusic3;


   public bool startPlaying;

   public BeatScroller theBS;
     
  public static GameManager instance;
  public int currentScore;
 public int scorePerNote = 50;
  public int scorePerGoodNote= 150;
  public int scorePerPerfectNote= 200;
    public Text scoreText;
 private float musicVolume =1f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text="Score: 0 ";
   theMusic.Play();
        instance = this;
    }

    // Update is called once per frame
    public void updateVolume(float volume)
 { 
  musicVolume=volume;
   }
    void Update()
    {
    theMusic.volume=musicVolume;
      if(!startPlaying)
     {
         if(Input.anyKeyDown)
           {
             startPlaying=true;
             theBS.hasStarted=true;
           
            }
      }
    
    }
public void NoteHit()
{
  currentScore+=scorePerNote;
  scoreText.text="Score: " + currentScore;
 }
  public void NoteMissed()

{
      theMusic3.Play();
   currentScore-=10;
  }

 public void NormalHit(){

  scoreText.text="Score: " + currentScore;

 }
  public void GoodHit(){

 currentScore+=scorePerGoodNote;
} 
 public void PerfectHit(){
 theMusic2.Play();
   scoreText.text="Score: " + currentScore;
 currentScore+=scorePerPerfectNote;
}
}
