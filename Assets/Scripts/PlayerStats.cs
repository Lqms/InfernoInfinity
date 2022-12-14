using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    public int Level => _level;
    public float Damage => _damage;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void SetNewCurrentHealth(float amount)
    {
        _currentHealth = amount;

        // ��� ������� ���� �� ������ ����� ���� � ������ ��� ������������ ��� ����� ����� ������ ������� ������ �� ������ � ����� �������� ����
    }
}
