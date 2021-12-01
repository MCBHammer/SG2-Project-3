using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerDeterminer;

public class Charge : ICommand
{
    PlayerType _type;
    PlayerData _playerData;
    EnemyData _enemyData;

    public Charge(PlayerType type, PlayerData playerData, EnemyData enemyData)
    {
        _type = type;
        _playerData = playerData;
        _enemyData = enemyData;
    }

    public void Execute()
    {
        switch (_type)
        {
            case PlayerType.PLAYER:
                Debug.Log("Player Charges");
                _playerData.Charge();
                break;

            case PlayerType.ENEMY:
                Debug.Log("Enemy Charges");
                _enemyData.Charge();
                break;

            case PlayerType.NULL:
                Debug.Log("How did we get here");
                break;
        }
    }

    public void Undo()
    {
        //I don't really need these I don't think
    }
}
