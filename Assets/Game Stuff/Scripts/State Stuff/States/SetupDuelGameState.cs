using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDuelGameState : DuelGameState
{
    [SerializeField] int _maxHealth = 5;

    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Entering Setup");
        Debug.Log("Reset Charges and Health to 0 when that gets functionality");
        _activated = false;
    }

    public override void Tick()
    {
        if(_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnDuelGameState>();
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Setup");
    }
}
