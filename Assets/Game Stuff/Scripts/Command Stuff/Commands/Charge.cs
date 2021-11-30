using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerDeterminer;

public class Charge : ICommand
{
    PlayerType _type;

    public Charge(PlayerType type)
    {
        _type = type;
    }

    public void Execute()
    {
        switch (_type)
        {
            case PlayerType.PLAYER:
                Debug.Log("Player Charges");
                //PlayerData.
                //add charge functionality here
                break;

            case PlayerType.ENEMY:
                Debug.Log("Enemy Charges");
                //add charge functionality here
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
