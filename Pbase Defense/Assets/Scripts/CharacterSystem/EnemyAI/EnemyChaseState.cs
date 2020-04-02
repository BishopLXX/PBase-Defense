using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter c):base(fsm,c)
    {
        _stateID = EnemyStateID.Chase;
    }

    private Vector3 _targetPosition;

    public override void DoBeforeEntering()
    {
        _targetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            _character.MoveTo(targets[0].position);
        } else
        {
            _character.MoveTo(_targetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(_character.position, targets[0].position);
            if (distance <= _character.atkRange)
            {
                _FSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }
}
