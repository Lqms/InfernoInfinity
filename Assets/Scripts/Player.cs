using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    public event UnityAction DoorEntered;
    public event UnityAction StartMoving;
    public event UnityAction EndMoving;

    private void OnEnable()
    {
        Door.Clicked += OnDoorClicked;
    }

    private void OnDisable()
    {
        Door.Clicked -= OnDoorClicked;
    }

    private void OnDoorClicked(Door choosenDoor, Door oppositeDoor)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MovingToNextRoom(choosenDoor.transform.position, oppositeDoor.transform.position));
    }

    private IEnumerator MovingToNextRoom(Vector2 choosenDoorPosition, Vector2 oppositeDoorPosition)
    {
        StartMoving?.Invoke();

        while (Vector2.Distance(transform.position, choosenDoorPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, choosenDoorPosition, _speed * Time.deltaTime);
            yield return null;
        }

        DoorEntered?.Invoke();
        transform.position = oppositeDoorPosition;

        while (Vector2.Distance(transform.position, Vector3.zero) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speed * Time.deltaTime);
            yield return null;
        }

        EndMoving?.Invoke();
    }
}