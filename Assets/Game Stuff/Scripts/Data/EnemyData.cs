using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    int health = 5;
    int charges = 0;
    int shields = 0;
    int shieldCooldown = 0;
    PlayerData _playerData = null;

    public int EnemyHealth { get { return health; } }
    public int EnemyCharges { get { return charges; } }
    public int EnemyShields { get { return shields; } }
    public int EnemyShieldCooldown { get { return shieldCooldown; } }

    private void Awake()
    {
        _playerData = this.GetComponent<PlayerData>();
    }

    public void Charge()
    {
        if (charges < 5)
            charges++;
    }

    public void Shield()
    {
        if (shields < 3 && shieldCooldown <= 0)
        {
            shields++;
            shieldCooldown = 2;
        }
    }

    public void Attack()
    {
        if (charges >= 1)
        {
            int damageDealt = charges - _playerData.PlayerShields;
            _playerData.TakeDamage(damageDealt);
            charges = 0;
        }
    }

    public void ShieldCountDown()
    {
        shieldCooldown--;
    }

    public void TakeDamage(int damageDealt)
    {
        if (damageDealt >= 0)
        {
            health -= damageDealt;
            shields = 0;
        }
        else
        {
            shields += damageDealt;
        }
    }
}
