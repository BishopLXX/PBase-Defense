using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade {
    private static GameFacade _instance = new GameFacade();
    private bool _isGameOver = false;
    public static GameFacade Instance { get { return _instance; } }

    public bool isGameOver{ get { return _isGameOver; } }

    private GameFacade() { }

    private ArchievementSystem _archievementSystem;
    private CampSystem _campSystem;
    private CharacterSystem _characterSystem;
    private EnergySystem _energySystem;
    private GameEventSystem _gameEventSystem;
    private StageSystem _stageSystem;

    private CampInfoUI _campInfoUI;
    private GamePauseUI _gamePauseUI;
    private GameStateInfoUI _gameStateInfoUI;
    private SoldierInfoUI _soldierInfoUI;

    public void Init()
    {
        _archievementSystem = new ArchievementSystem();
        _campSystem = new CampSystem();
        _characterSystem = new CharacterSystem();
        _energySystem = new EnergySystem();
        _gameEventSystem = new GameEventSystem();
        _stageSystem = new StageSystem();

        _gameStateInfoUI = new GameStateInfoUI();
        _campInfoUI = new CampInfoUI();
        _gamePauseUI = new GamePauseUI();
        _soldierInfoUI = new SoldierInfoUI();

        _archievementSystem.Init();
        _campSystem.Init();
        _characterSystem.Init();
        _energySystem.Init();
        _gameEventSystem.Init();
        _stageSystem.Init();

        _gameStateInfoUI.Init();
        _campInfoUI.Init();
        _gamePauseUI.Init();
        _soldierInfoUI.Init();
    }


    public void Update()
    {
        _archievementSystem.Update();
        _campSystem.Update();
        _characterSystem.Update();
        _energySystem.Update();
        _gameEventSystem.Update();
        _stageSystem.Update();

        _gameStateInfoUI.Update();
        _campInfoUI.Update();
        _gamePauseUI.Update();
        _soldierInfoUI.Update();
    }


    public void Release()
    {
        _archievementSystem.Release();
        _campSystem.Release();
        _characterSystem.Release();
        _energySystem.Release();
        _gameEventSystem.Release();
        _stageSystem.Release();

        _gameStateInfoUI.Release();
        _campInfoUI.Release();
        _gamePauseUI.Release();
        _soldierInfoUI.Release();
    }

    public Vector3 GetEnemyTargetPosition()
    {
        return Vector3.zero;
    }
}
