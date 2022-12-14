using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _upKey = KeyCode.W;
    [SerializeField] private KeyCode _downKey = KeyCode.S;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;

    public static event UnityAction<Vector2> DirectionKeyPressed;
    public static event UnityAction<Vector2> DirectionKeyPressing;

    private void Update()
    {
        if (Input.GetKeyDown(_upKey))
        {
            DirectionKeyPressed?.Invoke(Vector2.up);
        }

        if (Input.GetKeyDown(_downKey))
        {
            DirectionKeyPressed?.Invoke(Vector2.down);
        }

        if (Input.GetKeyDown(_leftKey))
        {
            DirectionKeyPressed?.Invoke(Vector2.left);
        }

        if (Input.GetKeyDown(_rightKey))
        {
            DirectionKeyPressed?.Invoke(Vector2.right);
        }
    }
}
