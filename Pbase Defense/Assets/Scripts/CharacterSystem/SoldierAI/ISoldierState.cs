using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition
{
    NullTansition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID
{
    NullState = 0,
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState {
    protected Dictionary<SoldierTransition, SoldierStateID> _map = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID _stateID;
    protected ICharacter _character;
    protected SoldierFSMSystem _FSM;

    public ISoldierState(SoldierFSMSystem fsm, ICharacter character)
    {
        _FSM = fsm;
        _character = character;
    }

    public SoldierStateID stateID { get { return _stateID; } }

    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTansition)
        {
            Debug.LogError("SoldierState Error: trans 不能为空");
            return;
        }
        if (id==SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error: id 状态ID不能为空");
            return;
        }
        if (_map.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error: " + trans + " 已经添加上了");
        }
        _map.Add(trans, id);   
    }

    public void DeleteTransition(SoldierTransition trans)
    {
        if (_map.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件不存在：" + trans);
        }
        _map.Remove(trans);
    }

    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if (_map.ContainsKey(trans) == false)
        {
            return SoldierStateID.NullState;
        } else
        {
            return _map[trans];
        }
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}
