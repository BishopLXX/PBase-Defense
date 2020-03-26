using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState {
    public StartState(SceneStateController controller):base("01StartScene", controller)
    {
        
    }
    private Image _Logo;
    private float _SmoothingSpeed = 1;
    private float _WaitTime = 2;

    public override void StateStart()
    {
        base.StateStart();
        _Logo = GameObject.Find("Canvas/Logo").GetComponent<Image>();
        _Logo.color = Color.black;
    }

    public override void StateUpdate()
    {
        _Logo.color = Color.Lerp(_Logo.color, Color.white, _SmoothingSpeed * Time.deltaTime);
        _WaitTime -= Time.deltaTime;
        if (_WaitTime<= 0)
        {
            _controller.SetState(new MainMenuState(_controller));
        }
    }
}

