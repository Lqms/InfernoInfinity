using UnityEngine;
using UnityEngine.UI;

public class QTEKey : MonoBehaviour
{
    [SerializeField] private Text _keyText;

    public KeyCode Key { get; private set; }

    public void GenerateKey()
    {
        Key = EnglishKeys.GetRandomKey();
        _keyText.text = Key.ToString();
    }  
}
