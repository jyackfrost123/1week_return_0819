using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using unityroom.Api;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
        
    [SerializeField]
    private TextMeshProUGUI timerText;
    
    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private GameObject endSE;

    [SerializeField]
    private GameObject SayonaraSE;

    [SerializeField]
    private GameObject gameoverButtons;

    [field: SerializeField] public bool isGameStart;
    [field: SerializeField] public bool isGameFinished;
    [field: SerializeField] public float time; 

    [SerializeField] public int score;

    private ParameterController para;

    public float firstTime; 

    public int deathNum = 0;

    public EnemyGenerator generator;

    
    
    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        isGameFinished = false;

        gameoverButtons.SetActive(false);
        
        score = 0;
        deathNum = 0;


        para = GameObject.Find("FadeManager").GetComponent<ParameterController>();
        para.deathSeasonig = 0;
        para.scoreTime = 0;

        firstTime = time;
    }

    void Update()
    {
        if (isGameStart)
        {
            time -= Time.deltaTime*2;
            if (time < 0.0f)
            {
                time = 0;
                isGameStart = false;
                deathNum = 4;
                GameFinish();
                DOVirtual.DelayedCall (3.0f, ()=> DoChangeScene());  
                //GameFinish();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "討伐数: "+ score +"匹";
        //timerText.text = "残り: " + time.ToString("f2") + "秒";
        timerText.text = "残り時間:  " + (int)(time / 60.0f) + ":"+ ( (int)(time % 60) ).ToString("00") ;
        
        //残り3秒以内
        if (time < 3.9f)
        {
            timerText.color = Color.red;
        }

    }
    
    //ゲーム終了時の処理
    public void GameFinish()
    {
        if(deathNum == 4){
            gameOverText.text = "FINISH!";
            gameOverText.color = Color.yellow;
            Destroy(generator.gameObject);
        }else{
            gameOverText.text = "BAD END";
            gameOverText.color = Color.red;
        }
        //para.TotalScore = player.AnimalTotalHight;
        //para.TotalAnimalNum = player.AnimalNum;
        isGameFinished = true;

        generator.StopGenerator();
        
        /* TODO: ランキング送信の処理を入れる*/
        //UnityroomApiClient.Instance.SendScore(1, (float)score, ScoreboardWriteMode.Always);

        //gameoverButtons.SetActive(true);

        para.scoreTime = firstTime - time;
        /*ToDO:死因をどうにかして渡す*/
        para.deathSeasonig = deathNum;

        

        if (deathNum == 4){
             FadeManager.Instance.LoadScene ("EndingScene", 2.0f);
             Instantiate(endSE, Vector3.zero, Quaternion.identity);
        }else {
            FadeManager.Instance.LoadScene ("ResultScene", 3.0f);
            Instantiate(SayonaraSE, Vector3.zero, Quaternion.identity);
        }
        
    }

    void DoChangeScene()
    {
        //フェード遷移とか入れる
        //FadeManager.Instance.LoadScene ("Ending", 1.5f);
    }

    public void AddScore(){
        if(isGameStart && !isGameFinished ) score++;
    }
}
