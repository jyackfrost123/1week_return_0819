using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Vector3 centerPos;

    public float MaxX, MinX, MaxY, MinY;

    public float speed;

    private float dx, dy;

    public int types;
    
    void Start()
    {
        dx = (this.transform.position.x - centerPos.x) / (speed * 30);
        dy = (this.transform.position.y - centerPos.y) / (speed * 30);

        /*if(this.transform.position.x  >= centerPos.x ) dx = dx;
        else dx = -dx;

        if(this.transform.position.y  >= centerPos.y ) dy = dy;
        else dy = -d;
        */
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {

        float x = transform.position.x;
        float y = transform.position.y;
         
        if(x < MinX || x > MaxX || y < MinY || y > MaxY){
            Destroy(this.gameObject);
        }

        transform.Translate(-dx, -dy, 0.0f);
    }
}
