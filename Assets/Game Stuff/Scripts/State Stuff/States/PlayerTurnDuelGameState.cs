using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerDeterminer;

public class PlayerTurnDuelGameState : DuelGameState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] Text _stateTextUI = null;

    int _playerTurnCount = 0;

    CommandStack _commandStack = new CommandStack();

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
        _commandStack.ExecuteCommand(new Attack(PlayerType.PLAYER));
        /*
        if(_playerTurnCount < 3)
        {
            StateMachine.ChangeState<WinDuelGameState>();
        } else
        {
            StateMachine.ChangeState<LoseDuelGameState>();
        }
        */  
    }

    void OnCharge()
    {
        Debug.Log("Charge");
        _commandStack.ExecuteCommand(new Charge(PlayerType.PLAYER));
        /*
        if (_playerTurnCount < 3)
        {
            StateMachine.ChangeState<EnemyTurnDuelGameState>();
        }
        else
        {
            StateMachine.ChangeState<LoseDuelGameState>();
        }
        */
    }

    void OnShield()
    {
        Debug.Log("Shield");
        _commandStack.ExecuteCommand(new Shield(PlayerType.PLAYER));
        /*
        if (_playerTurnCount < 3)
        {
            StateMachine.ChangeState<EnemyTurnDuelGameState>();
        }
        else
        {
            StateMachine.ChangeState<LoseDuelGameState>();
        }
        */
    }
}
