using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamerManager : MonoBehaviour
{
    
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float camSpeed;
    public GameObject fadePanel;

     void Start()
    {
        StartCoroutine(NeverFadeAway());

    }

    IEnumerator NeverFadeAway()
    {
        fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        fadePanel.GetComponent<RectTransform>().DOScale(0, 1f);
    }

     void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), camSpeed);
    }
}
