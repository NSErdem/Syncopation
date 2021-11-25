using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BeatScroller: MonoBehaviour
{
  public Transform Arrow;
  public float beatTempo;
  public bool hasStarted;


    // Start is called before the first frame update


    void Start()
    {   
        beatTempo=beatTempo/120f;
        StartCoroutine(SpawnArrow());

    }

    // Update is called once per frame
    void Update()
    {

       if(!hasStarted)
     {
        if(Input.anyKeyDown){
          hasStarted=true;
       }
     } else
     {
      transform.position -=new Vector3(0f,beatTempo *Time.deltaTime,0f);
       }
       
    }

 IEnumerator SpawnArrow()
{
   yield return new WaitForSeconds(beatTempo);
  generateArrow();
  StartCoroutine(SpawnArrow());

}
   void generateArrow()
   {
      Transform tempArrow;
      tempArrow= Instantiate(Arrow,Arrow.transform.position,Quaternion.identity);
            tempArrow.DOLocalMoveY(-10f,10f);

      

   }

}


 