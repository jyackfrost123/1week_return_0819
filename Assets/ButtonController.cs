using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using unityroom.Api;

public class ButtonController : MonoBehaviour
{

   ParameterController para;
   //public GameObject[] Omakes;
    
    
    void Start()
    {
     
     if(GameObject.Find("FadeManager") != null){
         para = GameObject.Find("FadeManager").GetComponent<ParameterController>(); 
     }
     
      
    }

    public void goTweet(){

        string str = "あなたは、せんべいディストピアで"+(int)(para.scoreTime)+"秒拷問に耐えました。";

        if(para.deathSeasonig == 4) str += "そして、世界の真実を知ってしまった…(TRUE END)";
        else {
            str += "しかし、";

            switch (para.deathSeasonig){
            default:
                str +="醤油";
                break;
            case 1:
                str +="黒豆";
                break;
            case 2:
                str +="われ";
                break;
            case 3:
                str +="のり";
                break;
            case 4:
                str +="海老";
                break;
        }

            str += "せんべいになってしまった…(BAD END)";
        }

       naichilab.UnityRoomTweet.Tweet ("komekashi_451_fahrenheit", str, "unity1week", "komekashi_451");
       //StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("ツイート本文をここに書く"));//画像あり
    }

    public void goRanking(){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
        UnityroomApiClient.Instance.SendScore(1, 1, ScoreboardWriteMode.Always);
    }

    public void goResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 0);
        UnityroomApiClient.Instance.SendScore(1, 1, ScoreboardWriteMode.Always);
    }
    
    
    /*
    public void go2ndRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 1);
    }

    public void go2ndResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 1);
    }
    */
    

    public void ReStart(){
        FadeManager.Instance.LoadScene ("GameScene", 0.5f);

        /*
        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameScene", 1.0f);
        }
        */
        
        
    }

    public void FastReStart(){
         SceneManager.LoadScene("GameScene");
    }

    public void Re2ndStart(){

        //FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);

        /*
        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);
        }
        */
        
        
    }

     public void Fast2ndReStart(){
         SceneManager.LoadScene("EndressGameScene");
    }

    public void goTutorial(){
        FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene ("Title", 0.5f);
    }

 
}
