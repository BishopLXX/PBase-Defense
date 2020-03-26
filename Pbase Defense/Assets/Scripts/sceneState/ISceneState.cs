using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景状态类
/// </summary>
public class ISceneState {
    /// <summary>
    /// 场景名字
    /// </summary>
    private string _sceneName;
    protected SceneStateController _controller;

    public ISceneState(string sceneName, SceneStateController controller)
    {
        _sceneName = sceneName;
        _controller = controller;
    }

    public string SceneName
    {
        get { return _sceneName; }
    }

    /// <summary>
    /// 每次进入状态的时候调用
    /// </summary>
    public virtual void StateStart()
    {

    }
    /// <summary>
    /// 每次离开状态的时候调用
    /// </summary>
    public virtual void StateEnd()
    {

    }

    public virtual void StateUpdate()
    {

    }
}
