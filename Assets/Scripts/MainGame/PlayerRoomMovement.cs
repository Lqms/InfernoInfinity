using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRoomMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Vector3 _startPosition;

    public event UnityAction MoveStarted;
    public event UnityAction<DoorNew> DoorEntered;
    public event UnityAction MoveEnded;

    private void OnEnable()
    {
        DoorNew.DoorButtonClicked += OnDoorButtonClicked;
    }

    private void OnDisable()
    {
        DoorNew.DoorButtonClicked -= OnDoorButtonClicked;
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnDoorButtonClicked(DoorNew clickedDoor)
    {
        StartCoroutine(MovingToNextRoom(clickedDoor));
    }

    private IEnumerator MovingToNextRoom(DoorNew clickedDoor)
    {
        Vector3 clickedDoorPosition = clickedDoor.transform.position;
        clickedDoorPosition.z = 0;

        Vector3 oppositeDoorPosition = clickedDoor.OppositeDoor.transform.position;
        oppositeDoorPosition.z = 0;

        MoveStarted?.Invoke();
        DoorNew.DoorButtonClicked -= OnDoorButtonClicked;

        while (Vector3.Distance(transform.position, clickedDoorPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, clickedDoorPosition, _speed * Time.deltaTime);
            yield return null;
        }

        DoorEntered?.Invoke(clickedDoor);
        transform.position = oppositeDoorPosition;

        while (Vector3.Distance(transform.position, _startPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);
            yield return null;
        }

        MoveEnded?.Invoke();
        DoorNew.DoorButtonClicked += OnDoorButtonClicked;
    }
}
