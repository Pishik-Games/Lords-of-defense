using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class MatchManager : MonoBehaviour
{
    //public static MatchManager _instance;
    //Dependecy
    [Inject]
    private WaveManager waveManager;
    //Dependecy
    public int WavesCount = 3;

    public int SecondsToWaveSTart = 10;

    //TODO A Report Manager For Player Stats And Game Details 

    public void Awake() {
        // if (_instance != null && _instance != this){
        //     Destroy(this);
        // }else{
        //     _instance = this;
        // }

        GameStateManager.GameState = GameStateManager.GameStates.MainGameIsRunning;
        waveManager = FindObjectOfType<WaveManager>().GetComponent<WaveManager>();
    }
    void Update()
    {
        
    }

    public static void MatchStart(){}
    public static void OnWaveStart(){}
    public static void LoseGame(){
        Time.timeScale = 0.01f;
        GameStateManager.GameState = GameStateManager.GameStates.PlayerLose;
        StopGameSystems();
    }
    public static void WinGame(){
        GameStateManager.GameState = GameStateManager.GameStates.PlayerWin;
        StopGameSystems();
    }
    public void OnWaveEnd(){
        Debug.Log("Remaining Time To Next Wave : "+SecondsToWaveSTart);
        StartCoroutine(SetTimeOut(()=> { 
            waveManager.WaveStart();
        },SecondsToWaveSTart));
    }
    void MatchEnd() { }

    public delegate void CallBack();
    IEnumerator SetTimeOut(CallBack callBack,int Seconds ){

        yield return new WaitForSeconds(Seconds);
        callBack();

    }

    private static void StopGameSystems(){
       // MatchManager._instance.StopWaveManager();
    }
    private void StopWaveManager(){
        waveManager.DestroyAllEnemies();
    }
}
