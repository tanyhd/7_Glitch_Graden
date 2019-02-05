using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float rotateSpeed = 900f;
    [SerializeField] int projectileDamage = 50;

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(-Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    private void Move()
    {
        transform.position += Vector3.right * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health attacker = collision.GetComponent<Health>();
        if (attacker != null)
        {
            attacker.DealDamage(projectileDamage);
        }
    }
}
