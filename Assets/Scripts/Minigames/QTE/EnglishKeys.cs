using UnityEngine;

public class EnglishKeys
{
    public static KeyCode[] Keys { get; private set; } =
    {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R,
        KeyCode.T,
        KeyCode.Y
    };

    public static KeyCode GetRandomKey()
    {
        int randomIndex = Random.Range(0, Keys.Length);

        return Keys[randomIndex];
    }
}
