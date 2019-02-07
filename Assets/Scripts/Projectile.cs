using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float rotateSpeed = 900f;
    [SerializeField] float projectileDamage = 50;

    [SerializeField] bool spike = false;

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

    private void OnTriggerEnter2D(Collider2D OtherCollider)
    {
        Health health = OtherCollider.GetComponent<Health>();
        Attacker attacker = OtherCollider.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.DealDamage(projectileDamage);
            if (!spike)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject, 3f);
            }
        }
    }
}
