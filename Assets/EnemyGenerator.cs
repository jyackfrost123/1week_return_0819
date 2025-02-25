using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject[] handtypes;
    public float radius = 0;

    public UIController ui;

    public Vector3 centerPos;

    int i;
    Tween tween;
    int n;

    void Start()
    {
        //tween = DOVirtual.DelayedCall(3f, () => {
        tween = DOVirtual.DelayedCall(1.5f, () => {
            i = Random.Range(0, handtypes.Length);
            //image.texture  = sprites[i];
            GenerateEnemy();
            }
        ).SetLoops(-1);

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void GenerateEnemy(){

        if(!ui.isGameStart) return;

        Debug.Log("Genrate!");
        
        float theta = Random.Range(0, 2 * Mathf.PI);

        //サインコサインの円形に配置したい
        float dx = centerPos.x + radius * Mathf.Sin(theta);
        float dy = centerPos.y + radius * Mathf.Cos(theta);
        //Debug.Log(dx + " : " + dy + " : "+radius * Mathf.Sin(theta) + " : " + radius * Mathf.Cos(theta));

        GameObject obj = Instantiate(handtypes[i], new Vector3(dx,dy,0), Quaternion.identity);
        obj.transform.parent = this.transform;

        
        EnemyController enemy = obj.GetComponent<EnemyController>();

        float randSpeed = Random.Range( 3.0f - ((ui.firstTime - ui.time) * 0.016f), 3.1f);
        if(randSpeed < 1.35f) randSpeed = 1.35f;

        enemy.speed = randSpeed;//残り時間(ui.firstTime - ui.time)から動的にしたい

        enemy.types = i;//番号設定

    }

    public void StopGenerator(){
        tween.Kill();
    }


}
