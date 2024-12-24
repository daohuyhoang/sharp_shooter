using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] GameObject projectileHitVFX;

    Rigidbody rb;
    int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.TakeDamage(damage);
        }

        Instantiate(projectileHitVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
