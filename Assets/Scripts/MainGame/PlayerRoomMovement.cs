using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Vector3 _startPosition;

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

    private void OnDoorButtonClicked(DoorNew door)
    {
        Vector3 clickedDoorPosition = door.transform.position;
        clickedDoorPosition.z = 0;

        Vector3 oppositeDoorPosition = door.OppositeDoor.transform.position;
        oppositeDoorPosition.z = 0;

        StartCoroutine(MovingToNextRoom(clickedDoorPosition, oppositeDoorPosition, _startPosition));
    }

    private IEnumerator MovingToNextRoom(Vector3 clickedDoorPosition, Vector3 oppositeDoorPosition, Vector3 finalPosition)
    {
        while (Vector3.Distance(transform.position, clickedDoorPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, clickedDoorPosition, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = oppositeDoorPosition;

        while (Vector3.Distance(transform.position, finalPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
