using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevZhrssh.Managers;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float damage;

    private AudioManager audioManager;

    private float currentTime = 0f;
    private float despawnTime = 2f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("gun-shoot");

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * 40f;
    }

    private void Update()
    {
        // Destroys bullet to avoid over spawning
        currentTime += Time.deltaTime;
        if (currentTime > despawnTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks for enemy script
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);

        Destroy(gameObject); // Destroys the bullet on hit
    }
}
