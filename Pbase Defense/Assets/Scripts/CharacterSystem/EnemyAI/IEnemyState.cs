using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTransition
{
    NullTansition = 0,
    CanAttack,
    LostSoldier,
}

public enum EnemyStateID
{
    NullState = 0,
    Chase,
    Attack
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> _map = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID _stateID;
    protected ICharacter _character;
    protected EnemyFSMSystem _FSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        _FSM = fsm;
        _character = character;
    }

    public EnemyStateID stateID { get { return _stateID; } }

    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTansition)
        {
            Debug.LogError("EnemyState Error: trans 不能为空");
            return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyState Error: id 状态ID不能为空");
            return;
        }
        if (_map.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error: " + trans + " 已经添加上了");
        }
        _map.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (_map.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件不存在：" + trans);
        }
        _map.Remove(trans);
    }

    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (_map.ContainsKey(trans) == false)
        {
            return EnemyStateID.NullState;
        }
        else
        {
            return _map[trans];
        }
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}