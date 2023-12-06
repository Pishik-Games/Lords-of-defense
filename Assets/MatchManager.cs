using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager _instance;
    public int WavesCount = 3;

    public int SecondsToWaveSTart = 10;

    //TODO A Report Manager For Player Stats And Game Details 

    public void Awake() {
        if (_instance != null && _instance != this){
            Destroy(this);
        }else{
            _instance = this;
        }
    }
    void Update()
    {
        
    }

    void MatchStart(){}
    void OnWaveStart(){}
    void PlayeLose(){}
    void PlayerWin(){}
    public void  OnWaveEnd()
    {
        Debug.Log("Remaining Time To Next Wave : "+SecondsToWaveSTart);
        StartCoroutine(SetTimeOut(()=> { 
            WaveManager._instance.WaveStart();
        },SecondsToWaveSTart));
    }
    void MatchEnd() { }

    public delegate void CallBack();
    IEnumerator SetTimeOut(CallBack callBack,int Seconds ){

        yield return new WaitForSeconds(Seconds);
        callBack();

    }
}
