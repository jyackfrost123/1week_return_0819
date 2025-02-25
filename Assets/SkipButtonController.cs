using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class SkipButtonController : MonoBehaviour
{
    public Flowchart flowchart;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

        // スキップボタン押下時
    public void pushSkipButton()
    {
        Debug.Log("Call");

        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        
        // 現在のブロックを停止する
        flowchart.StopAllBlocks();
        // 会話終了
        //flowchart.ExecuteBlock(GameUtil.Const.FUNGUS_END_BLOCK);

        // スキップボタン無効化
        this.gameObject.SetActive(false);

        FadeManager.Instance.LoadScene ("Title", 0.5f);
    }

     public void pushSkipButtonforEnd()
    {
        Debug.Log("Call");

        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        
        // 現在のブロックを停止する
        flowchart.StopAllBlocks();
        // 会話終了
        //flowchart.ExecuteBlock(GameUtil.Const.FUNGUS_END_BLOCK);

        // スキップボタン無効化
        this.gameObject.SetActive(false);

        FadeManager.Instance.LoadScene ("ResultScene", 0.5f);
    }
}
