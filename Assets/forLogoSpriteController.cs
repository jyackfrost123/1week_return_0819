using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class forLogoSpriteController : MonoBehaviour
{

    public RawImage image;
    public Texture[] sprites;

    int i = 0;
    
    void Start()
    {
    
        DOVirtual.DelayedCall(0.3f, () => {
            i++;
            if(i > sprites.Length - 1) i = 0;  
            image.texture  = sprites[i];
            }
        ).SetLoops(-1);

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
