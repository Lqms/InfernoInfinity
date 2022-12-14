using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public event UnityAction Died;

    private void Start()
    {
        if (_maxHealth < _currentHealth)
            _maxHealth = _currentHealth;
    }

    public void Restore(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, _currentHealth, _maxHealth);
    }

    public void ApplyDamage(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, _maxHealth);

        if (_currentHealth == 0)
        {
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}
