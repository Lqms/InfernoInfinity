using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum RoomType
{
    Minigame,
    Simple
}

public class RoomTypeDeterminer : MonoBehaviour
{
    [SerializeField] private Player _player;

    public RoomType CurrentRoom { get; private set; }

    public event UnityAction MinigameRoomEntered;

    private void OnEnable()
    {
        _player.StartMoving += OnStartMoving;
        _player.DoorEntered += OnDoorEntered;
        _player.EndMoving += OnEndMoving;
    }

    private void OnDisable()
    {
        _player.StartMoving -= OnStartMoving;
        _player.DoorEntered -= OnDoorEntered;
        _player.EndMoving -= OnEndMoving;
    }

    private void OnStartMoving()
    {
        int randomNumber = Random.Range(0, 2);

        if (randomNumber == 0)
        {
            CurrentRoom = RoomType.Minigame;
        }
        else if (randomNumber == 1)
        {
            CurrentRoom = RoomType.Simple;
        }
    }

    private void OnDoorEntered()
    {
        // тут будет визуальная смена сцены сначала

        if (CurrentRoom == RoomType.Minigame)
        {
            Camera.main.backgroundColor = Color.red;
        }
        else
        {
            Camera.main.backgroundColor = Color.white;
        }
    }

    private void OnEndMoving()
    {
        if (CurrentRoom == RoomType.Minigame)
            MinigameRoomEntered?.Invoke();
    }
}
