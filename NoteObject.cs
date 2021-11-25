using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class NoteObject : MonoBehaviour
{
 
public static bool canBePressed;
public static bool kral;
public static bool kral2;
public KeyCode keyToPress;

public GameObject den;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) &&!kral)
        {
            GameManager.instance.NoteMissed();
            //Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
        if (Input.GetKeyDown(keyToPress))
        {


            if (canBePressed)
            {



                if (Mathf.Abs(transform.position.y) > 0.20)
                {
                    kral = true;
                    kral2 = false;
                   // GameManager.instance.PerfectHit();
                   // Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.10f)
                {
                    
                    kral2 = false;
                 // GameManager.instance.PerfectHit();
                   // Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect Hit");


                  //  Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }

                gameObject.SetActive(false);

            }



        }

        
    }

private void OnTriggerEnter2D(Collider2D other)
   {
    if(other.tag=="Activator")
 {  
   
   canBePressed=true; 
  kral =true;
  kral2=false;
    }
       }

  private void OnTriggerExit2D(Collider2D other)
{
if (other.tag =="Activator")
{
      canBePressed=false;
             kral=false;
            kral2=true;
        Destroy(gameObject);
}
}
}
