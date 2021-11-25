using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyManager : MonoBehaviour
{

    bool isColliderBusy = false;
    
    
    public float health=100f;
    
    public float damage=10f;

    public float flashTime=0.1f;
    Color originalColor;
    
    public Slider slider;
    public Transform floatingText;

    void Start()
    {
       
       originalColor = GetComponent<SpriteRenderer>().color;
       slider.maxValue = health;
       slider.value = health;
    }

    void Update()
    {   
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player") && !isColliderBusy)
        {
            isColliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }       
        else if(other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().BulletDamage);
            Destroy(other.gameObject);

        }
    }
  
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isColliderBusy = false;
        }
    }
    public void GetDamage(float damage)
    {   

        FlashRed();

        if((health - damage) >= 0) 
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
    }

    void AmIDead()
    {
        if(health <= 0)
        {   
            Destroy(gameObject);
            
        }
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
    
    
}
