using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float startAttackRate;

    private float attackRate;
    void Start()
    {
        attackRate = 0;
    }

    void Update()
    {
        attackRate -= Time.deltaTime;

        if (attackRate <= 0)
        {
            attackRate = 0;
        }
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = firePoint.position;
    }

    public void Attacking()
    {
        if(attackRate <= 0)
        {
            SpawnBullet();
            attackRate = startAttackRate;
        }
    }

    public void ChangeAttackRate(float rate)
    {
        attackRate -= rate;
    }
}
