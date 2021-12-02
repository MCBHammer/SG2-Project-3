using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDataDisplay : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData = null;
    [SerializeField] Image _healthImage = null;
    [SerializeField] Image _chargeImage = null;
    [SerializeField] Image _shieldImage = null;
    [SerializeField] Sprite[] _healthSprites = new Sprite[6];
    [SerializeField] Sprite[] _chargeSprites = new Sprite[6];
    [SerializeField] Sprite[] _shieldSprites = new Sprite[4];

    private void OnEnable()
    {
        EnemyTurnDuelGameState.EnemyTurnBegan += StatsUpdate;
        EnemyTurnDuelGameState.EnemyTurnEnded += StatsUpdate;
        PlayerTurnDuelGameState.PlayerTurnBegan += StatsUpdate;
        PlayerTurnDuelGameState.PlayerTurnEnded += StatsUpdate;
    }

    void StatsUpdate()
    {
        if (_enemyData.EnemyHealth < 0)
        {
            _healthImage.sprite = _healthSprites[0];
        }
        else if (_enemyData.EnemyHealth > 5)
        {
            _healthImage.sprite = _healthSprites[5];
        }
        else
        {
            _healthImage.sprite = _healthSprites[_enemyData.EnemyHealth];
        }

        if (_enemyData.EnemyCharges < 0)
        {
            _chargeImage.sprite = _chargeSprites[0];
        }
        else if (_enemyData.EnemyCharges > 5)
        {
            _chargeImage.sprite = _chargeSprites[5];
        }
        else
        {
            _chargeImage.sprite = _chargeSprites[_enemyData.EnemyCharges];
        }

        if (_enemyData.EnemyShields < 0)
        {
            _shieldImage.sprite = _shieldSprites[0];
        }
        else if (_enemyData.EnemyShields > 3)
        {
            _shieldImage.sprite = _shieldSprites[3];
        }
        else
        {
            _shieldImage.sprite = _shieldSprites[_enemyData.EnemyShields];
        }
    }
}

