using UnityEngine;
using System;
using System.Collections;

//Game states

    public enum GameState { INTRO, MAIN_MENU}

    public delegate void OnStateChangeHandler();

    public class GameManager
{
    protected GameManager() { }
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }

    }

    public void SetGameState(GameState state)
    {

    }
}