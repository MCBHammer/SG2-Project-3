using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerDeterminer;
using System;

public class PlayerTurnDuelGameState : DuelGameState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] Text _stateTextUI = null;
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] EnemyData _enemyData = null;

    int _playerTurnCount = 0;

    public static event Action PlayerTurnBegan;
    public static event Action PlayerTurnEnded;

    CommandStack _commandStack = new CommandStack();

    public override void Enter()
    {
        Debug.Log("Entering Player Turn");
        _playerTurnTextUI.gameObject.SetActive(true);

        _stateTextUI.text = ("State: Player Turn State");
        PlayerTurnBegan?.Invoke();

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        StateMachine.Input.PressedAttack += OnAttack;
        StateMachine.Input.PressedCharge += OnCharge;
        StateMachine.Input.PressedShield += OnShield;
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        _playerData.ShieldCountDown();
        PlayerTurnEnded?.Invoke();
        Debug.Log("Exiting Player Turn");
        StateMachine.Input.PressedAttack -= OnAttack;
        StateMachine.Input.PressedCharge -= OnCharge;
        StateMachine.Input.PressedShield -= OnShield;
    }

    void OnAttack()
    {
        if(_playerData.PlayerCharges >= 1)
        {
            Debug.Log("Attack!");
            _commandStack.ExecuteCommand(new Attack(PlayerType.PLAYER, _playerData, _enemyData));
            if(_enemyData.EnemyHealth <= 0)
            {
                StateMachine.ChangeState<WinDuelGameState>();
            }
            else
            {
                StateMachine.ChangeState<EnemyTurnDuelGameState>();
            }
        }
        else
        {
            //Visual/Audio feedback that charges are empty
        }
    }

    void OnCharge()
    {
        if (_playerData.PlayerCharges < 5)
        {
            Debug.Log("Charge");
            _commandStack.ExecuteCommand(new Charge(PlayerType.PLAYER, _playerData, _enemyData));
            StateMachine.ChangeState<EnemyTurnDuelGameState>();
        } else
        {
            //Visual/Audio feedback that charges are full
        }
    }

    void OnShield()
    {
        if(_playerData.PlayerShields < 3)
        {
            if(_playerData.PlayerShieldCooldown <= 0)
            {
                Debug.Log("Shield");
                _commandStack.ExecuteCommand(new Shield(PlayerType.PLAYER, _playerData, _enemyData));
                StateMachine.ChangeState<EnemyTurnDuelGameState>();
            } 
            else
            {
                //Visual/Audio feedback that shield is on cooldown
            }  
        }
        else
        {
            //Visual/Audio feedback that shields are full
        } 
    }
}
