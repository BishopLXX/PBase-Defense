using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController {

    private ISceneState _state;
    private AsyncOperation _ao;
    private bool _isRunStart = false;

    public void SetState(ISceneState state,bool isLoadScene = true)
    {
        if (_state != null)
        {
            _state.StateEnd();
        }
        _state = state;
        if (isLoadScene)
        {
            _ao = SceneManager.LoadSceneAsync(_state.SceneName);
            _isRunStart = false;
        }
        else
        {
            _state.StateStart();
            _isRunStart = true;
        }
        
    }

    public void StateUpdate()
    {
        if (_ao != null && _ao.isDone == false) return;

        if (_isRunStart== false && _ao != null && _ao.isDone == true)
        {
            _state.StateStart();
            _isRunStart = true;
        }


        if (_state != null)
        {
            _state.StateUpdate();
        }
    }
}
