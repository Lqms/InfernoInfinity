using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float _currentPower;
    [SerializeField] private float _maxPower;
    [SerializeField] private ParticleSystem _effect;

    public void IncreasePower()
    {
        if (_currentPower >= _maxPower)
        {
            return;
        }

        _currentPower++;
        _effect.emissionRate *= _currentPower;
    }
}
