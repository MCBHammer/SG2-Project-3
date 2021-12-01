using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] EnemyData _enemyData = null;
    [SerializeField] Text _text = null;

    void Update()
    {
        _text.text = "Debug Text:" + "\n" + "Player Health: " + _playerData.PlayerHealth + "\n" + "Player Charges: " + _playerData.PlayerCharges + "\n"
            + "Player Shields: " + _playerData.PlayerShields + "\n" + "Player Shield Cooldown: " + _playerData.PlayerShieldCooldown + "\n" +
            "Enemy Health: " + _enemyData.EnemyHealth + "\n" + "Enemy Charges: " + _enemyData.EnemyCharges + "\n"
            + "Enemy Shields: " + _enemyData.EnemyShields + "\n" + "Enemy Shield Cooldown: " + _enemyData.EnemyShieldCooldown;
    }
}
