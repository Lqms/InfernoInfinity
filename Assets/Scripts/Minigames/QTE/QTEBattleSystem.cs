using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QTEBattleSystem : MonoBehaviour
{
    [SerializeField] private QTEChecker _qteChecker;
    [SerializeField] private QTETimer _qteTimer;

    [Header("Healths")]
    [SerializeField] private float _playerHealth;
    [SerializeField] private float _enemyHealth;

    private PlayerStats _playerStats;

    private void OnEnable()
    {
        _qteChecker.KeyChecked += OnKeyChecked;
        _qteTimer.TimeOvered += OnTimeOvered;
        MinigameManager.MiniGameStarted += OnMiniGameStarted;
    }

    private void OnDisable()
    {
        _qteChecker.KeyChecked -= OnKeyChecked;
        _qteTimer.TimeOvered -= OnTimeOvered;
        MinigameManager.MiniGameStarted -= OnMiniGameStarted;
    }

    private void OnKeyChecked(bool right)
    {
        if (right)
        {
            _enemyHealth -= _playerStats.Damage;

            if (_enemyHealth <= 0)
                MinigameOverHandler.GameOver(_playerStats, _playerHealth);
        }
        else
        {
            _playerHealth -= _playerStats.Level;

            if (_playerHealth <= 0)
                MinigameOverHandler.GameOver(_playerStats, _playerHealth);
        }

        _qteTimer.SetNewTimer(30 / _playerStats.Level);
    }

    private void OnTimeOvered()
    {
        _enemyHealth += _playerStats.Level;
    }

    private void OnMiniGameStarted(PlayerStats playerStats)
    {
        _playerStats = playerStats;
        _qteTimer.SetNewTimer(30 / _playerStats.Level); // придумать интересную формулу, которая чем выше левел игрока тем меньше таймер, но при этом статы игрока могут и увеличивать этот таймер
        _playerHealth = _playerStats.CurrentHealth;
        _enemyHealth = _playerStats.Level * 10;
    }
}
