using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
 
    private Transform _parent;

    private void Start()
    {
        _parent = transform.parent;
    }

    private void OnDisable()
    {
        transform.position = _parent.position;
    }

    private void Update()
    {
        transform.position = transform.position + transform.up * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Shield shield))
        {
            shield.IncreasePower();
            gameObject.SetActive(false);
        }
        
        if(collision.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
