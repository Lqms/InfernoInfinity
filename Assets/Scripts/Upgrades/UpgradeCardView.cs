using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCardView : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;
    [SerializeField] private Image _image;

    public void Init(UpgradeCard info)
    {
        _title.text = info.Title;
        _description.text = info.Description;
        _image.sprite = info.Image;
    }
}
