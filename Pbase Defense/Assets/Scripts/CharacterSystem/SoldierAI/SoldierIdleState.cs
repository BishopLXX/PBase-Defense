using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : ISoldierState {

    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        _stateID = SoldierStateID.Idle;
        
    }

    public override void Act(List<ICharacter> targets)
    {
        _character.PlayAnim("stand");
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            _FSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}
