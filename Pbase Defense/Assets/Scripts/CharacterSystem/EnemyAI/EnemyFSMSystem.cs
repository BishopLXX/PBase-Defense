using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFSMSystem {
    private List<IEnemyState> _states = new List<IEnemyState>();

    private IEnemyState _currentState;
    public IEnemyState currentState { get { return _currentState; } }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState s in states)
        {
            AddState(s);
        }
    }

    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空");
            return;
        }
        if (_states.Count == 0)
        {
            _states.Add(state);
            _currentState = state;
            _currentState.DoBeforeEntering();
            return;
        }

        foreach (IEnemyState s in _states)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态已存在：" + s.stateID);
                return;
            }
        }
        _states.Add(state);
    }
    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态为空：" + stateID);
        }
        foreach (IEnemyState s in _states)
        {
            if (s.stateID == stateID)
            {
                _states.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的StateID不存在集合中: " + stateID);
    }
    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTansition)
        {
            Debug.LogError("要执行的转换条件为空：" + trans);
            return;
        }
        EnemyStateID nextStateID = _currentState.GetOutPutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在当前[" + _currentState.stateID + " ]状态下，没有转换条件为[" + trans + "]的下一个状态");
        }
        foreach (IEnemyState s in _states)
        {
            if (s.stateID == nextStateID)
            {
                _currentState.DoBeforeLeaving();
                _currentState = s;
                _currentState.DoBeforeEntering();
                return;
            }
        }
    }

}
