using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataDisplay : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] Image _healthImage = null;
    [SerializeField] Image _chargeImage = null;
    [SerializeField] Image _shieldImage = null;
    [SerializeField] Sprite[] _healthSprites = new Sprite[6];
    [SerializeField] Sprite[] _chargeSprites = new Sprite[6];
    [SerializeField] Sprite[] _shieldSprites = new Sprite[4];

    private void OnEnable()
    {
        PlayerTurnDuelGameState.PlayerTurnBegan += StatsUpdate;
        PlayerTurnDuelGameState.PlayerTurnEnded += StatsUpdate;
    }

    void StatsUpdate()
    {
        if(_playerData.PlayerHealth <= 0)
        {
            _healthImage.sprite = _healthSprites[0];
        } else if (_playerData.PlayerHealth > 5)
        {
            _healthImage.sprite = _healthSprites[5];
        } else
        {
            _healthImage.sprite = _healthSprites[_playerData.PlayerHealth];
        }

        if (_playerData.PlayerCharges < 0)
        {
            _chargeImage.sprite = _chargeSprites[0];
        }
        else if (_playerData.PlayerCharges > 5)
        {
            _chargeImage.sprite = _chargeSprites[5];
        }
        else
        {
            _chargeImage.sprite = _chargeSprites[_playerData.PlayerCharges];
        }

        if (_playerData.PlayerShields < 0)
        {
            _shieldImage.sprite = _shieldSprites[0];
        }
        else if (_playerData.PlayerShields > 3)
        {
            _shieldImage.sprite = _shieldSprites[3];
        }
        else
        {
            _shieldImage.sprite = _shieldSprites[_playerData.PlayerShields];
        }
    }
}
