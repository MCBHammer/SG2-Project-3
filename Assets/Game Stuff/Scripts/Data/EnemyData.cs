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

    [SerializeField] AudioClip _chargeAudio = null;
    [SerializeField] AudioClip _shieldAudio = null;
    [SerializeField] AudioClip _hitAudio = null;
    [SerializeField] AudioClip _bigHitAudio = null;
    [SerializeField] AudioClip _blockAudio = null;

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
        {
            charges++;
            AudioHelper.PlayClip2D(_chargeAudio, 0.5f);
        }
    }

    public void Shield()
    {
        if (shields < 3 && shieldCooldown <= 0)
        {
            shields++;
            shieldCooldown = 2;
            AudioHelper.PlayClip2D(_shieldAudio, 0.5f);
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
            AudioHelper.PlayClip2D(_hitAudio, 0.5f);
            if (damageDealt > 2)
            {
                AudioHelper.PlayClip2D(_bigHitAudio, 0.5f);
            }
            if (damageDealt == 0)
            {
                AudioHelper.PlayClip2D(_blockAudio, 0.5f);
            }
        }
        else
        {
            shields += damageDealt;
            AudioHelper.PlayClip2D(_blockAudio, 0.5f);
        }
    }
}
