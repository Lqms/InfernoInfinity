using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCardsGenerator : MonoBehaviour
{
    [SerializeField] private UpgradeCard[] _cards;
    [SerializeField] private UpgradeCardView[] _cardsView;

    private void Start()
    {
        foreach (var cardView in _cardsView)
        {
            cardView.Init(_cards[Random.Range(0, _cards.Length)]);
        }
    }
}
