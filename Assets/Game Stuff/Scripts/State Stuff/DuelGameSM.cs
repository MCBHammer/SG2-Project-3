using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelGameSM : StateMachine
{
    void Start()
    {
        ChangeState<SetupDuelGameState>();
    }
}
