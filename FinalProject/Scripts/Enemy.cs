using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float fireInterval = 2f; // 銃弾を発射する間隔

    public Transform playerTransform;

    private float nextFireTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time + fireInterval;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireInterval;
        }
    }

    void FireBullet()
    {
        Vector3 directionToPlayer = playerTransform.position - bulletSpawnPoint.position;
        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotationToPlayer);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }
}
