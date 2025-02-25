using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpningBackgroundController : MonoBehaviour
{
    
    void Start()
    {
        //transform.DOShakePosition(1f, 1f, 30, 1, false, true).SetLoops(-1, LoopType .Yoyo);
    }

    void Update()
    {
         transform.DOShakePosition(3f, 3f, 30, 1, false, true).SetLoops(-1, LoopType .Yoyo);
    }

    void FixedUpdate()
    {
        
    }
}
