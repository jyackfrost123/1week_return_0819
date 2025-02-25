using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterController : MonoBehaviour
{
    public float scoreTime;
    public int deathSeasonig;
    /*0 = 醤油せんべい
      1 = 黒豆せんべい
      2 = われせんべい
      3 = のりせんべい
      4 = 海老せんべい
    */

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    public void ResetScores(){
        scoreTime = 0;
        deathSeasonig = 0;
    }
}
