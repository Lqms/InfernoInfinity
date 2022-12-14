using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Room : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Door[] _doors;

    private void OnEnable()
    {
        _player.DoorEntered += OnDoorEntered;
        _player.StartMoving += OnPlayerStartMoving;
        _player.EndMoving += OnPlayerEndMoving;
    }

    private void OnDisable()
    {
        _player.DoorEntered -= OnDoorEntered;
        _player.StartMoving -= OnPlayerStartMoving;
        _player.EndMoving -= OnPlayerEndMoving;
    }

    private void OnDoorEntered()
    {
        int activeDoorsCounter = 0;

        foreach (Door door in _doors)
        {
            door.gameObject.SetActive(true);

            if (door != Door.Closed)
            {
                int randomState = Random.Range(0, 2);
                activeDoorsCounter += randomState;
                door.gameObject.SetActive(randomState != 0);
            }
        }

        if (activeDoorsCounter == 0)
        {
            var doorsTemp = _doors.Where(door => door != Door.Closed).ToList();
            doorsTemp[Random.Range(0, doorsTemp.Count)].gameObject.SetActive(true);
        }
    }

    private void OnPlayerStartMoving()
    {
        foreach (Door door in _doors)
        {
            door.SwitchColliderEnabling(false);
        }
    }

    private void OnPlayerEndMoving()
    {
        foreach (Door door in _doors)
        {
            door.SwitchColliderEnabling(true);
        }
    }
}
