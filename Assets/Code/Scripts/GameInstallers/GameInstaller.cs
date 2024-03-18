using System;
using UnityEngine;
using Zenject;
public class GameInstaller : MonoInstaller<GameInstaller>{

    [Header("Managers")]
    [SerializeField]public GameObject matchManager;
    [SerializeField]public GameObject waveManager;

    [Header("Factories")]
    [SerializeField]public GameObject enemyFactory;

    [Header("Player")]
    [SerializeField]public GameObject Player;
    public override void InstallBindings(){
        //Container.Instantiate<ProjectileManager>();
        InstallMatchManager();
        InstallWaveManager();
        InstallPlayer();
    }
    private void InstallMatchManager(){
        Container.Bind<MatchManager>().FromInstance(matchManager.GetComponent<MatchManager>()).AsSingle();
    }

    private void InstallWaveManager(){
        Container.Bind<WaveManager>().FromInstance(waveManager.GetComponent<WaveManager>()).AsSingle();
        Container.Bind<EnemyFactory>().FromInstance(enemyFactory.GetComponent<EnemyFactory>()).AsSingle();
    }

    private void InstallPlayer(){
        var playerAnimator = Player.GetComponentInChildren<Animator>();
        var playerAnimHandler = playerAnimator.gameObject.AddComponent<PlayerAnimHandler>();
        playerAnimHandler.animator = playerAnimator;
        Container.Bind<PlayerAnimHandler>().FromInstance(playerAnimHandler).AsSingle();
    }
}
