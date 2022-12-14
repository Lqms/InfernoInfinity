using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomNew : MonoBehaviour
{
    [SerializeField] private DoorNew[] _doors;
    [SerializeField] private PlayerRoomMovement _player;

    private DoorNew _blockedDoor;

    private void OnEnable()
    {
        _player.MoveStarted += OnPlayerMoveStarted;
        _player.DoorEntered += OnPlayerDoorEntered;
        _player.MoveEnded += OnPlayerMoveEnded;
    }

    private void OnDisable()
    {
        _player.MoveStarted -= OnPlayerMoveStarted;
        _player.DoorEntered -= OnPlayerDoorEntered;
        _player.MoveEnded -= OnPlayerMoveEnded;
    }

    private void OnPlayerMoveStarted()
    {
        
    }

    private void OnPlayerDoorEntered(DoorNew clickedDoor)
    {
        if (_blockedDoor != null)
        {
            _blockedDoor.Activate();
        }

        _blockedDoor = clickedDoor.OppositeDoor;
        _blockedDoor.Deactivate();
    }

    private void OnPlayerMoveEnded()
    {

    }
}
