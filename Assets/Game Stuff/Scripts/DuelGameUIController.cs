using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelGameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyTurnTextUI = null;

    private void OnEnable()
    {
        EnemyTurnDuelGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnDuelGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnDuelGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnDuelGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    private void Start()
    {
        _enemyTurnTextUI.gameObject.SetActive(false);
    }

    void OnEnemyTurnBegan()
    {
        //_enemyTurnTextUI.gameObject.SetActive(true);
    }

    void OnEnemyTurnEnded()
    {
        //_enemyTurnTextUI.gameObject.SetActive(false);
    }
}
