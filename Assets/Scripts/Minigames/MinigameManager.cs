using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private RoomTypeDeterminer _roomTypeDeterminer;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private MainGame _mainGame;

    [SerializeField] private Minigame[] _minigames;

    private Minigame _currentMinigame;

    public static event UnityAction<PlayerStats> MiniGameStarted;

    private void OnEnable()
    {
        _roomTypeDeterminer.MinigameRoomEntered += OnMinigameRoomEntered;
        MinigameOverHandler.MinigameOvered += OnMinigameOvered;
    }

    private void OnDisable()
    {
        _roomTypeDeterminer.MinigameRoomEntered -= OnMinigameRoomEntered;
        MinigameOverHandler.MinigameOvered -= OnMinigameOvered;
    }

    private void OnMinigameRoomEntered()
    {
        _currentMinigame = _minigames[Random.Range(0, _minigames.Length)];
        _currentMinigame.gameObject.SetActive(true);
        _mainGame.gameObject.SetActive(false);
        StartNewMiniGame(_playerStats);
    }

    public static void RandomNewMiniGame(PlayerStats playerStats)
    {
        
    }

    private void StartNewMiniGame(PlayerStats playerStats)
    {
        MiniGameStarted?.Invoke(playerStats);
    }

    private void OnMinigameOvered()
    {
        _currentMinigame.gameObject.SetActive(false);
        _mainGame.gameObject.SetActive(true);
    }
}
