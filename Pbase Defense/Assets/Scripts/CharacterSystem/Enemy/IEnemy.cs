using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : ICharacter {
    protected EnemyFSMSystem _FSMSystem;

    public IEnemy()
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
        _FSMSystem = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(_FSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(_FSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        _FSMSystem.AddState(chaseState, attackState);
    }

}
