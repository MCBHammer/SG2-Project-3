using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerDeterminer;

public class Shield : ICommand
{
    PlayerType _type;
    PlayerData _playerData;
    EnemyData _enemyData;

    public Shield(PlayerType type, PlayerData playerData, EnemyData enemyData)
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
                Debug.Log("Player Shields");
                _playerData.Shield();
                break;

            case PlayerType.ENEMY:
                Debug.Log("Enemy Shields");
                _enemyData.Shield();
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
