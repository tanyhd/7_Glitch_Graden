using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float rotateSpeed = 900f;

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
}
