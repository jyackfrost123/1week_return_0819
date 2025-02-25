using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class gamingBackgroundController : MonoBehaviour
{
    
    void Start()
    {
        transform.DOShakePosition(3f, 0.05f, 10, 10, false, false).SetLoops(-1);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
