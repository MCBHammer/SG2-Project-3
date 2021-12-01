using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using PlayerDeterminer;

public class EnemyTurnDuelGameState : DuelGameState
{
    [SerializeField] Text _stateTextUI = null;
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] EnemyData _enemyData = null;

    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    CommandStack _commandStack = new CommandStack();

    public override void Enter()
    {
        Debug.Log("Entering Enemy Turn");
        EnemyTurnBegan?.Invoke();

        _stateTextUI.text = ("State: Enemy Turn State");
        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Exiting Enemy Turn");
        _enemyData.EnemyShieldCooldown--;
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy Thinking...");
        yield return new WaitForSeconds(pauseDuration);

        EnemyAI();
        Debug.Log("Enemy Performs Action");
        EnemyTurnEnded?.Invoke();
        if (_playerData.PlayerHealth <= 0)
        {
            StateMachine.ChangeState<LoseDuelGameState>();
        }
        else
        {
            StateMachine.ChangeState<PlayerTurnDuelGameState>();
        }
        
    }

    public void EnemyAI()
    {
        if(_enemyData.EnemyCharges - _playerData.PlayerShields >= 2)
        {
            Debug.Log("Attack!");
            _commandStack.ExecuteCommand(new Attack(PlayerType.ENEMY, _playerData, _enemyData));
            return;
        }
        if(_enemyData.EnemyCharges >= 5 && (_enemyData.EnemyShields >= 3 || _enemyData.EnemyShieldCooldown > 0))
        {
            Debug.Log("Attack!");
            _commandStack.ExecuteCommand(new Attack(PlayerType.ENEMY, _playerData, _enemyData));
            return;
        }
        if(_enemyData.EnemyCharges == 0 && (_enemyData.EnemyShields >= 3 || _enemyData.EnemyShieldCooldown > 0))
        {
            Debug.Log("Charge");
            _commandStack.ExecuteCommand(new Charge(PlayerType.ENEMY, _playerData, _enemyData));
            return;
        }
        if(_enemyData.EnemyCharges == 0 && _enemyData.EnemyShields < 3 && _enemyData.EnemyShieldCooldown <= 0)
        {
            float _random = UnityEngine.Random.value;
            if(_random <= 0.5f)
            {
                Debug.Log("Charge");
                _commandStack.ExecuteCommand(new Charge(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
            else
            {
                Debug.Log("Shield");
                _commandStack.ExecuteCommand(new Shield(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
        }
        if (_enemyData.EnemyCharges >= 5 && _enemyData.EnemyShields < 3 && _enemyData.EnemyShieldCooldown <= 0)
        {
            float _random = UnityEngine.Random.value;
            if (_random <= 0.75f)
            {
                Debug.Log("Attack!");
                _commandStack.ExecuteCommand(new Attack(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
            else
            {
                Debug.Log("Shield");
                _commandStack.ExecuteCommand(new Shield(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
        }
        if (_enemyData.EnemyCharges < 5 && (_enemyData.EnemyShields >= 3 || _enemyData.EnemyShieldCooldown > 0))
        {
            float _random = UnityEngine.Random.value;
            if (_random <= 0.75f)
            {
                Debug.Log("Charge");
                _commandStack.ExecuteCommand(new Charge(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
            else
            {
                Debug.Log("Attack!");
                _commandStack.ExecuteCommand(new Attack(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
        }
        if (_enemyData.EnemyCharges < 5 && _enemyData.EnemyShields < 3 && _enemyData.EnemyShieldCooldown <= 0)
        {
            float _random = UnityEngine.Random.value;
            if (_random <= 0.2f)
            {
                Debug.Log("Attack!");
                _commandStack.ExecuteCommand(new Attack(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
            else if(_random <= 0.6f)
            {
                Debug.Log("Shield");
                _commandStack.ExecuteCommand(new Shield(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
            else
            {
                Debug.Log("Charge");
                _commandStack.ExecuteCommand(new Charge(PlayerType.ENEMY, _playerData, _enemyData));
                return;
            }
        }
    }
}
