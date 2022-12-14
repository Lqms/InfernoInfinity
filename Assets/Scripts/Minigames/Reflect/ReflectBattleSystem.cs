using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBattleSystem : MonoBehaviour
{
    [Header("Healths")]
    [SerializeField] private float _playerHealth;
    [SerializeField] private float _enemyHealth;

    private PlayerStats _playerStats;

    private void OnEnable()
    {
        MinigameManager.MiniGameStarted += OnMiniGameStarted;
    }

    private void OnDisable()
    {
        MinigameManager.MiniGameStarted -= OnMiniGameStarted;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _playerHealth -= _playerStats.Level * 10;

            if (_playerHealth <= 0)
                MinigameOverHandler.GameOver(_playerStats, _playerHealth);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            _enemyHealth -= _playerStats.Damage;

            if (_enemyHealth <= 0)
                MinigameOverHandler.GameOver(_playerStats, _playerHealth);
        }
    }

    private void OnMiniGameStarted(PlayerStats playerStats)
    {
        _playerStats = playerStats;
        _playerHealth = _playerStats.CurrentHealth;
        _enemyHealth = _playerStats.Level * 10;
    }
}
