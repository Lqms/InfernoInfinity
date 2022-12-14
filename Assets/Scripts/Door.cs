using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Door _oppositeDoor;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    public static Door Closed { get; private set; }

    public static event UnityAction<Door, Door> Clicked;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _player.DoorEntered += OnDoorEntered;
    }

    private void OnDisable()
    {
        _player.DoorEntered -= OnDoorEntered;
    }

    private void OnMouseDown()
    {
        if (Closed != this)
        {
            Closed = _oppositeDoor;
            Clicked?.Invoke(this, Closed);
        }
    }

    public void SwitchColliderEnabling(bool state)
    {
        _boxCollider.enabled = state;
    }

    private void OnDoorEntered()
    {
        _spriteRenderer.color = Color.white;
        Closed._spriteRenderer.color = Color.gray;
    }
}
