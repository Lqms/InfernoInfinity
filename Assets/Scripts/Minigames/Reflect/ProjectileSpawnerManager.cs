using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerManager : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner[] _projectileSpawners;
    [SerializeField] private float _timeBetweenShots;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting() 
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenShots);
            int randomIndex = Random.Range(0, _projectileSpawners.Length);
            _projectileSpawners[randomIndex].Shoot();
        }
    }
}
