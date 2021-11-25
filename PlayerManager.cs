using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    Animator PlayerAnimator;
    bool dead = false;
    Transform muzzle;
    
    public float flashTime=0.1f;
    Color originalColor;
    public Transform bullet;
    public Vector3 player_loc;
    

    public float health=100f;
    public float bulletSpeed=10f;

    [SerializeField]
    public float shotFrequency=1f, nextShotTime;

    [SerializeField]
    bool isShooting = false;
    [SerializeField]
    private float hpPercent;
    public RectTransform rt;
    public RectTransform RhythmBar;

    public GameObject deadPanel;
    public float player_posy;
      public NoteObject noteObject;
      
      public timer Timer;

bool isDead;
    void Start()
    {
isDead=false;
        deadPanel.SetActive(false);
        PlayerAnimator = GetComponent<Animator>();
        muzzle= transform.GetChild(1);
        originalColor = GetComponent<SpriteRenderer>().color;
        
    }

    void Update()
    {
        bool counter = NoteObject.canBePressed;
        isDead=false;

        isDead = timer.isDead;
        if(Input.GetAxis("space") > 0 && (nextShotTime < Time.timeSinceLevelLoad)&&counter)
        {
            nextShotTime = Time.timeSinceLevelLoad + shotFrequency;
            shootBullet();
            
        }
        PlayerAnimator.SetBool("isPlayerShooting", isShooting);
        isShooting=false;
        player_loc= GameObject.Find("Player").transform.position;
        player_posy = player_loc.y;
        fallingDead();
updateRhythmBar();
timesUp();
        
    }

    public void GetDamage(float damage)
    {   
        
        FlashRed();
        if(health - damage >= 0) 
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        AmIDead();
        updateHpBar();
    }

    void AmIDead()
    {
        if((health <= 0))
        {
            dead = true;
            
            showDeadPanel();
            Destroy(gameObject);


        }
        
    }

       void timesUp()
    {
        if((isDead==true))
        {
            dead = true;
            
            showDeadPanel();
            Destroy(gameObject);


        }
        
    }

    void shootBullet()
    {   Transform tempbullet;
        tempbullet= Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempbullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward*bulletSpeed);
        isShooting=true;
    }

    void FlashRed()
 {
     GetComponent<SpriteRenderer>().color = Color.red;
     Invoke("ResetColor", flashTime);
 }
    void ResetColor()
 {
      GetComponent<SpriteRenderer>().color = originalColor;
 }
    
public void updateHpBar()
    {
        rt.sizeDelta = new Vector2(210,210);
        hpPercent=(health/100);
        rt.sizeDelta = new Vector2(rt.sizeDelta.x,rt.sizeDelta.y*hpPercent);
    }

public void updateRhythmBar()
{        bool rhythmTime = NoteObject.canBePressed;

                if(rhythmTime==true)
            {
            RhythmBar.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
                //RhythmBar.sizeDelta = new Vector2(210,210);
            }
            else{
            RhythmBar.GetComponent<CanvasGroup>().DOFade(0, 0.5f);

                //RhythmBar.sizeDelta = new Vector2(0,0);

            }
}

void showDeadPanel()
    {
        deadPanel.SetActive(true);
        Time.timeScale=0;
      
    }

    public void restartButton()
    {
        Time.timeScale=1;
        deadPanel.SetActive(false);
        SceneManager.LoadScene(1);
    } 

    void fallingDead()
    {
        if((player_posy <= -25f))
        {
            dead = true;
            
            showDeadPanel();
            Destroy(gameObject);
        }
    }
}
