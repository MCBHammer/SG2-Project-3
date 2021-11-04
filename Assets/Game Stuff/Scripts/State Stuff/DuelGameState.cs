using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuelGameState : State
{
    protected DuelGameSM StateMachine { get; private set; }

    void Awake()
    {
        StateMachine = GetComponent<DuelGameSM>();
        StateMachine.Input.PressedLeave += OnLeave;
    }

    void OnLeave()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
