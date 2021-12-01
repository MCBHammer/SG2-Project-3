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

    public int PlayerHealth { get { return health; } set { health -= value; } }
    public int PlayerCharges { get { return charges; } }
    public int PlayerShields{ get { return shields; } set { shields = value; } }
    public int PlayerShieldCooldown { get { return shieldCooldown; } set { shieldCooldown -= value; } }

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
            if(damageDealt >= 0)
            {
                _enemyData.EnemyHealth -= damageDealt;
                _enemyData.EnemyShields = 0;
            } else
            {
                _enemyData.EnemyShields += damageDealt;
            }
        }
    }
}
