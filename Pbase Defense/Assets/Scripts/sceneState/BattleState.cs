using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : ISceneState {
    public BattleState(SceneStateController controller) : base("03BattleScene", controller)
    {
        
    }

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }

    public override void StateUpdate()
    {
        if (GameFacade.Instance.isGameOver)
        {
            _controller.SetState(new MainMenuState(_controller));
        }

        GameFacade.Instance.Update();
    }
}
