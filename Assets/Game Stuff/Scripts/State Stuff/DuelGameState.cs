using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelGameState : State
{
    protected DuelGameSM StateMachine { get; private set; }

    void Awake()
    {
        StateMachine = GetComponent<DuelGameSM>();
    }
}
