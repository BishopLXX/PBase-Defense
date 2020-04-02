using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFSMSystem {

    private List<ISoldierState> _states = new List<ISoldierState>();

    private ISoldierState _currentState;
    public ISoldierState currentState { get { return _currentState; } }

    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            AddState(s);
        }
    }

    public void AddState(ISoldierState state)
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
            return;
        }

        foreach ( ISoldierState s in _states)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态已存在：" + s.stateID);
                return;
            }
        }
        _states.Add(state);
    }
    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("要删除的状态为空：" + stateID);
        }
        foreach (ISoldierState s in _states)
        {
            if (s.stateID == stateID)
            {
                _states.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的StateID不存在集合中: " + stateID);
    }
    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTansition)
        {
            Debug.LogError("要执行的转换条件为空：" + trans);
            return;
        }
        SoldierStateID nextStateID = _currentState.GetOutPutState(trans);
        if (nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("在当前[" + _currentState.stateID + " ]状态下，没有转换条件为[" + trans + "]的下一个状态");
        }
        foreach (ISoldierState s in _states)
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
