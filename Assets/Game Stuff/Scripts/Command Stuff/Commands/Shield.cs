using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerDeterminer;

public class Shield : ICommand
{
    PlayerType _type;

    public Shield(PlayerType type)
    {
        _type = type;
    }

    public void Execute()
    {
        switch (_type)
        {
            case PlayerType.PLAYER:
                Debug.Log("Player Shields");
                //add shield functionality here
                break;

            case PlayerType.ENEMY:
                Debug.Log("Enemy Shields");
                //add shield functionality here
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
