using UnityEngine;
using UnityEngine.Events;

public class KeyChecker : MonoBehaviour
{
    public event UnityAction<KeyCode> KeyPressed;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in EnglishKeys.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    KeyPressed?.Invoke(key);
                    break;
                }
            }
        }
    }
}
