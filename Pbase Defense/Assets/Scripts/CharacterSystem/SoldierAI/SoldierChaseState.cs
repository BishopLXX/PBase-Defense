using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        _stateID = SoldierStateID.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            _character.MoveTo(targets[0].position);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            _FSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }

        float distance = Vector3.Distance(targets[0].position, _character.position);
        if (distance <= _character.atkRange)
        {
            _FSM.PerformTransition(SoldierTransition.CanAttack);
        }
    }
}
