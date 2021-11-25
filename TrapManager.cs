using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TrapManager : MonoBehaviour
{
    public GameObject Trap;
    public GameObject Trap2;
    public GameObject Trap3;

     void Awake() {
                StartCoroutine(ActivateTrap());
                StartCoroutine(ActivateTrap2());
                StartCoroutine(ActivateTrap3());


    }
    void Start()
    {         

                StartCoroutine(ActivateTrap());
                StartCoroutine(ActivateTrap2());
                StartCoroutine(ActivateTrap2());
    }

    void Update()
    {
                StartCoroutine(ActivateTrap());
                StartCoroutine(ActivateTrap2());
                StartCoroutine(ActivateTrap3());

    }
IEnumerator ActivateTrap()
{   yield return new WaitForSeconds(10f);
     Trap.SetActive(false);
  StartCoroutine(ActivateTrap());

}
  IEnumerator ActivateTrap2()
{   yield return new WaitForSeconds(8f);
     Trap2.SetActive(false);
  StartCoroutine(ActivateTrap2());

}
IEnumerator ActivateTrap3()
{   yield return new WaitForSeconds(4f);
     Trap3.SetActive(false);
  StartCoroutine(ActivateTrap3());

}
}
