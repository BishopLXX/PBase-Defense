using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISoldier : ICharacter {
    protected SoldierFSMSystem _FSMSystem;

    public ISoldier() : base()
    {
        MakeFSM();
    }

    public void UpdateFSMAI(List<ICharacter> targets)
    {
        _FSMSystem.currentState.Reason(targets);
        _FSMSystem.currentState.Act(targets);
    }

    private void MakeFSM()
    {
        _FSMSystem = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(_FSMSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(_FSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(_FSMSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        _FSMSystem.AddState(idleState, chaseState, attackState);
    }
}
