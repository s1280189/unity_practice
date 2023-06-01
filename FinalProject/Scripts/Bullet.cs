using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 1f;
    public string targetTag = "Wall";

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, lifetime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Functions function;
            GameObject obj = GameObject.Find("Functions");
            function = obj.GetComponent<Functions>();

            other.gameObject.SetActive(false);
            function.count = function.count + 1;

            function.SetCountText();

        }
    }
}