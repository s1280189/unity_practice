using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bullet : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Functions function;
            GameObject obj = GameObject.Find("Functions");
            function = obj.GetComponent<Functions>();

            function.countHP = function.countHP - 1;

            function.SetHPText();
            Destroy(gameObject);

        }
    }

}
