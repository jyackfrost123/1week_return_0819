using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    public float moveX;
    public float moveY;

    public Sprite[] senbeiSprites;

    private SpriteRenderer playerSprite;

    [SerializeField, Header("半径")]
    float radius;

    [SerializeField]
    Vector3 centerPos; 

    Vector3 mousePos, worldPos;

    public float rightX, leftX, topY, buttomY;

    public UIController ui;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //自身と円形に移動制限させたい位置の中心点との距離を測り半径以上になっていれば処理
        /*if (Vector3.Distance(transform.position,centerPos) < radius)
        {
            
            if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ){
                //if (Input.GetKey(KeyCode.LeftShift)  ||Input.GetKey(KeyCode.RightShift)  ){}
                //else 
                if(Vector3.Distance(transform.position + new Vector3(0, moveY, 0),centerPos) < radius) transform.Translate(0, moveY, 0);
            }else if( Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ){
                if(Vector3.Distance(transform.position + new Vector3(0, -moveY, 0),centerPos) < radius) transform.Translate(0, -moveY, 0);
            }

            if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
                if(Vector3.Distance(transform.position + new Vector3(-moveX, 0, 0),centerPos) < radius) transform.Translate(-moveX, 0, 0);
            }else if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
                if(Vector3.Distance(transform.position + new Vector3(moveX, 0, 0),centerPos) < radius) transform.Translate(moveX, 0, 0);
            }

            if( Input.GetMouseButton(1) ){
                    playerSprite.sprite = senbeiSprites[1];
            }else{
                    playerSprite.sprite = senbeiSprites[0];
            }
        }
        */
        //マウス座標の取得
        mousePos = Input.mousePosition;
        //スクリーン座標をワールド座標に変換
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,10f));
        //ワールド座標を自身の座標に設定
        //if(leftX <= worldPos.x && worldPos.x <= rightX && buttomY <= worldPos.y && worldPos.y <= topY) transform.position = worldPos;

        if(leftX > worldPos.x) worldPos.x = leftX;
        else if(worldPos.x > rightX) worldPos.x = rightX ;

        if(topY < worldPos.y) worldPos.y = topY;
        else if(worldPos.y < buttomY) worldPos.y = buttomY ;

        transform.position = worldPos;


        Restriction();

    }

    void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(transform.position,centerPos));
    }

     void Restriction()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touch!");
        //Debug.Log("YES");
        if (collision.gameObject.tag == "Enemy")
        {
            int num = collision.gameObject.GetComponent<EnemyController>().types;
            /*if(posNum == num && !isDeath  && !ui.isGameFinished){
                isDelete = true;
                ui.GameOver();
            }*/
            ui.deathNum = num;
            ui.GameFinish();
            this.gameObject.SetActive(false);
        }
    }
}
