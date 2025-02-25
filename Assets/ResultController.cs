using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using unityroom.Api;
using Fungus;

public class ResultController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI shokaiText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI belowText;

    [SerializeField] private Sprite[] SenbeiSprites;
    [SerializeField] private SpriteRenderer resultSprite;

    private ParameterController para;
    
    void Start()
    {

        para = GameObject.Find("FadeManager").GetComponent<ParameterController>();

        //ランキング送信
        UnityroomApiClient.Instance.SendScore(1, para.scoreTime, ScoreboardWriteMode.HighScoreDesc);
        
        timeText.text = "焼き時間: "+ (int)(para.scoreTime / 60)+":"+ (para.scoreTime - (int)(para.scoreTime / 60)*60 ).ToString("00");

        string valliation = "";  

        switch (para.deathSeasonig){
            default:
                valliation="醤油";
                break;
            case 1:
                valliation="黒豆";
                break;
            case 2:
                valliation="われ";
                break;
            case 3:
                valliation="のり";
                break;
            case 4:
                valliation="海老";
                break;
        }

        resultSprite.sprite = SenbeiSprites[para.deathSeasonig];

        shokaiText.text = "<size=35>美味しい</size><size=60>"+valliation+"せんべい</size><size=35>になりました</size>";
        
        if(para.deathSeasonig != 2)belowText.text = "香ばしい"+valliation+"の風味!";
        else belowText.text = "割れているから食べやすい!";
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
