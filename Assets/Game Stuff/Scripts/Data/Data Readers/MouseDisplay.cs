using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDisplay : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] Image _leftClick = null;
    [SerializeField] Image _rightClick = null;
    [SerializeField] Image _spaceBar = null;
    [SerializeField] Sprite _leftClickGreen = null;
    [SerializeField] Sprite _rightClickGreen = null;
    [SerializeField] Sprite _spaceBarGreen = null;
    [SerializeField] Sprite _leftClickRed = null;
    [SerializeField] Sprite _rightClickRed = null;
    [SerializeField] Sprite _spaceBarRed = null;

    private void OnEnable()
    {
        PlayerTurnDuelGameState.PlayerTurnBegan += StatsUpdate;
        PlayerTurnDuelGameState.PlayerTurnEnded += StatsUpdate;
        EnemyTurnDuelGameState.EnemyTurnBegan += StatsUpdate;
        EnemyTurnDuelGameState.EnemyTurnEnded += StatsUpdate;
    }

    void StatsUpdate()
    {
        if(_playerData.PlayerCharges > 0)
        {
            _leftClick.sprite = _leftClickGreen;
        } else
        {
            _leftClick.sprite = _leftClickRed;
        }

        if (_playerData.PlayerCharges < 5)
        {
            _rightClick.sprite = _rightClickGreen;
        }
        else
        {
            _rightClick.sprite = _rightClickRed;
        }

        if (_playerData.PlayerShields < 3 && _playerData.PlayerShieldCooldown <= 0)
        {
            _spaceBar.sprite = _spaceBarGreen;
        }
        else
        {
            _spaceBar.sprite = _spaceBarRed;
        }
    }
}

