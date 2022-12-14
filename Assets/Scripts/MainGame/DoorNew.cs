using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DoorNew : MonoBehaviour
{
    [SerializeField] private Button _doorButton;
    [SerializeField] private DoorNew _oppositeDoor;

    public DoorNew OppositeDoor => _oppositeDoor;

    public static event UnityAction<DoorNew> DoorButtonClicked;

    private void OnEnable()
    {
        _doorButton.onClick.AddListener(OnDoorButtonClicked);
    }

    private void OnDisable()
    {
        _doorButton.onClick.RemoveListener(OnDoorButtonClicked);
    }

    private void OnDoorButtonClicked()
    {
        DoorButtonClicked?.Invoke(this);
    }
}
