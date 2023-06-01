using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float rotationSpeed = 150; // 回転速度
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isFiring;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.drag = 1f; // 慣性を減らすためにドラッグを追加
        count = 0;

    }
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 10, 0));
        if(isFiring)
        {
            FireBullet();
            isFiring = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnFire()
    {
        isFiring = true;
    }

    void FixedUpdate()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Functions function;
            GameObject obj = GameObject.Find("Functions");
            function = obj.GetComponent<Functions>();

            function.countHP = function.countHP - 1;

            function.SetHPText();

        }
    }


    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }
}