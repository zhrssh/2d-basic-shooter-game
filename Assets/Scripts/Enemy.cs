using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;

    private Transform target;
    private Rigidbody2D rb;
    private Quaternion rotation;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (target == null)
            return;

        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        rotation = Quaternion.LookRotation(Vector3.forward, direction);

    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = transform.up * moveSpeed;
            rb.SetRotation(rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the enemy reached the player
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
