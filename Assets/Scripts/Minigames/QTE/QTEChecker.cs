using UnityEngine;
using UnityEngine.Events;

public class QTEChecker : MonoBehaviour
{
    [SerializeField] private KeyChecker _keyChecker;
    [SerializeField] private QTEKey _qteKey;

    public event UnityAction<bool> KeyChecked;

    private void OnEnable()
    {
        _keyChecker.KeyPressed += OnKeyPressed;
    }

    private void OnDisable()
    {
        _keyChecker.KeyPressed -= OnKeyPressed;
    }

    private void OnKeyPressed(KeyCode key)
    {
        KeyChecked?.Invoke(key == _qteKey.Key);
    }
}
