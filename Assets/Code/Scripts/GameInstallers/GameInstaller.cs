using System;
using BoostingSystem;
using UnityEngine;
using Zenject;
public class GameInstaller : MonoInstaller<GameInstaller>{

    [Header("Managers")]
    [SerializeField]public GameObject matchManager;
    [SerializeField]public GameObject waveManager;

    [Header("Factories")]
    [SerializeField]public GameObject enemyFactory;
    [SerializeField]public GameObject boostFactory;

    [Header("Player")]
    [SerializeField]public GameObject player;
    [SerializeField]public Player playerScript;
    [SerializeField] public GameObject playerStatsUI;

    [Header("Player")]
    [SerializeField] public GameObject townHall;
    public override void InstallBindings(){
        //Container.Instantiate<ProjectileManager>();
        InstallMatchManager();
        InstallWaveManager();
        InstallBoostingSystem();
        InstallPlayer();
        InstallTownHall();
    }

    private void InstallMatchManager(){
        Container.Bind<MatchManager>().FromInstance(matchManager.GetComponent<MatchManager>()).AsSingle();
    }

    private void InstallWaveManager(){
        Container.Bind<WaveManager>().FromInstance(waveManager.GetComponent<WaveManager>()).AsSingle();
        Container.Bind<EnemyFactory>().FromInstance(enemyFactory.GetComponent<EnemyFactory>()).AsSingle();
    }

    private void InstallBoostingSystem()
    {
        Container.Bind<BoostFactory>().FromInstance(boostFactory.GetComponent<BoostFactory>()).AsSingle();
    }

    private void InstallPlayer(){
        playerScript = player.GetComponent<Player>();
        Container.Bind<Player>().FromInstance(playerScript).AsSingle();

        var playerAnimator = player.GetComponentInChildren<Animator>();
        var playerAnimHandler = playerAnimator.gameObject.AddComponent<PlayerAnimHandler>();
        playerAnimHandler.animator = playerAnimator;
        Container.Bind<PlayerAnimHandler>().FromInstance(playerAnimHandler).AsSingle();

        var playerStat = player.AddComponent<playerStats>();
        var _playerStatsUI = playerStatsUI.AddComponent<PlayerStatsUI>();
        playerStats.playerStatsUI = _playerStatsUI;
    }

    public void InstallTownHall(){
        var townHallScript = townHall.AddComponent<TownHall>();
        var townHalHeathlManger = townHall.AddComponent<TownHalHeathlManger>();
        townHallScript.townHalHeathlManger = townHalHeathlManger;
        townHalHeathlManger.townHallScript = townHallScript;

        var townHallStat = townHall.AddComponent<TownHallStats>();
        var _TownHallStatsUI = townHall.AddComponent<TownHallStatsUI>();
        TownHallStats.TownHallStatsUI = _TownHallStatsUI;
    }
}
