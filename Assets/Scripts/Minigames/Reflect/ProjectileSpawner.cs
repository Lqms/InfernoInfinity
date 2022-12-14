using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    private List<Projectile> _projectiles;

    private void Start()
    {
        _projectiles = new List<Projectile>();
    }

    public void Shoot()
    {
        var projectile = _projectiles.FirstOrDefault(p => p.gameObject.activeSelf == false);

        if (projectile == null)
        {
            projectile = Instantiate(_projectilePrefab, transform);
            _projectiles.Add(projectile);
        }

        projectile.gameObject.SetActive(true);
    }
}
