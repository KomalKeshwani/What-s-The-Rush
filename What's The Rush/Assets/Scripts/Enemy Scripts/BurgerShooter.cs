using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject burgerBullet;

    [SerializeField]
    private Transform bulletSpawnPos;

    [SerializeField]
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;


    private float waitTime;

    private void Start()
    {
        waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
    }

    private void Update()
    {
        if(Time.time > waitTime)
        {
            waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(burgerBullet, bulletSpawnPos.position, Quaternion.identity);
    }









    
}//class





