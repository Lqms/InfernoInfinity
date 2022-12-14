using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectPlayer : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 5;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        PlayerInput.DirectionKeyPressed += OnDirectionKeyPressed;
    }

    private void OnDisable()
    {
        PlayerInput.DirectionKeyPressed -= OnDirectionKeyPressed;
    }

    private void OnDirectionKeyPressed(Vector2 direction)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Rotating(direction));
    }

    private IEnumerator Rotating(Vector3 direction)
    {
        Quaternion newRotation = Quaternion.LookRotation(direction - transform.position, Vector3.back);
        newRotation.x = 0;
        newRotation.y = 0;

        while (transform.rotation != newRotation)
        {
            // transform.rotation = Quaternion.LerpUnclamped(transform.rotation, newRotation, Time.deltaTime * 50);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, _rotateSpeed);
            yield return null;
        }
    }
}
