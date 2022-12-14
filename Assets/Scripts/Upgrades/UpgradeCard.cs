using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create upgrade card", fileName = "Upgrade", order = 54)]
public class UpgradeCard : ScriptableObject
{
    [SerializeField] private Sprite _image;
    [SerializeField] private string _title;
    [SerializeField] private string _description;

    public Sprite Image => _image;
    public string Title => _title;
    public string Description => _description;
}
