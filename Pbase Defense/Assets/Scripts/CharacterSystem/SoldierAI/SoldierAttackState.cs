using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : ISoldierState {

    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        _stateID = SoldierStateID.Attack;
        _AttackTimer = _AttackTime;
    }

    private float _AttackTime = 1;
    private float _AttackTimer = 1;

    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
        _AttackTimer += Time.deltaTime;
        if (_AttackTimer >= _AttackTime)
        {
            _character.Attack(targets[0]);
            _AttackTimer = 0;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets ==null || targets.Count == 0)
        {
            _FSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(_character.position, targets[0].position);
        if (distance > _character.atkRange)
        {
            _FSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}
