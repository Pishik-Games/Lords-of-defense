using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStateManager{
    public static GameStates GameState;

    public enum GameStates{
        GamePasuse,
        MainGameIsRunning,
        PlayerWin,
        PlayerLose,
    }
}
