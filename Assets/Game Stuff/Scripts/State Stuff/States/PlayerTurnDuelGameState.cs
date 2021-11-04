using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnDuelGameState : DuelGameState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] Text _stateTextUI = null;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Entering Player Turn");
        _playerTurnTextUI.gameObject.SetActive(true);

        _stateTextUI.text = ("State: Player Turn State");

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        StateMachine.Input.PressedAttack += OnAttack;
        StateMachine.Input.PressedCharge += OnCharge;
        StateMachine.Input.PressedShield += OnShield;
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        Debug.Log("Exiting Player Turn");
        StateMachine.Input.PressedAttack -= OnAttack;
        StateMachine.Input.PressedCharge -= OnCharge;
        StateMachine.Input.PressedShield -= OnShield;
    }

    void OnAttack()
    {
        Debug.Log("Attack!");
        if(_playerTurnCount < 3)
        {
            StateMachine.ChangeState<WinDuelGameState>();
        } else
        {
            StateMachine.ChangeState<LoseDuelGameState>();
        }
        
    }

    void OnCharge()
    {
        Debug.Log("Charge");
        if (_playerTurnCount < 3)
        {
            StateMachine.ChangeState<EnemyTurnDuelGameState>();
        }
        else
        {
            StateMachine.ChangeState<LoseDuelGameState>();
        }
    }

    void OnShield()
    {
        Debug.Log("Shield");
        if (_playerTurnCount < 3)
        {
            StateMachine.ChangeState<EnemyTurnDuelGameState>();
        }
        else
        {
            StateMachine.ChangeState<LoseDuelGameState>();
        }
    }
}
