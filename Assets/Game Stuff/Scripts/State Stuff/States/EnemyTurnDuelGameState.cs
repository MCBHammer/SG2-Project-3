using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnDuelGameState : DuelGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("Entering Enemy Turn");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Exiting Enemy Turn");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy Thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy Performs Action");
        EnemyTurnEnded?.Invoke();
        StateMachine.ChangeState<PlayerTurnDuelGameState>();
    }
}
