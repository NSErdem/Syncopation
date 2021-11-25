using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyME : MonoBehaviour
{
    public int lifeTime = 1;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

        void Update()
    {
        
    }
}
