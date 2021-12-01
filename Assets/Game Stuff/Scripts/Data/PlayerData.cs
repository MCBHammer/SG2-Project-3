using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int health = 5;
    int charges = 0;
    int shields = 0;
    int shieldCooldown = 0;
    EnemyData _enemyData = null;

    public int PlayerHealth { get { return health; } }
    public int PlayerCharges { get { return charges; } }
    public int PlayerShields{ get { return shields; } }
    public int PlayerShieldCooldown { get { return shieldCooldown; } }

    private void Awake()
    {
        _enemyData = this.GetComponent<EnemyData>();
    }

    public void Charge()
    {
        if(charges < 5)
            charges++;
    }

    public void Shield()
    {
        if(shields < 3 && shieldCooldown <= 0)
        {
            shields++;
            shieldCooldown = 2;
        }
    }

    public void Attack()
    {
        if(charges >= 1)
        {
            int damageDealt = charges - _enemyData.EnemyShields;
            _enemyData.TakeDamage(damageDealt);
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
