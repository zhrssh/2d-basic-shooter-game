using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevZhrssh.Managers;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float health;

    private GameManager gameManager;
    private AudioManager audioManager;

    protected float time = 0;
    protected float interval = 0.01f;

    protected bool canBeDamaged;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();

        health = maxHealth;
        canBeDamaged = true;
    }

    protected virtual void Update()
    {
        // Handles the interval of getting damaged
        time += Time.deltaTime;
        if (time > interval)
        {
            canBeDamaged = true;
        }

        // Checks if the entity has health left
        if (health <= 0)
        {
            audioManager.Play("death");
            gameManager.AddScore();
            Destroy(gameObject);
        }
    }

    // Public Functions
    public virtual void TakeDamage(float damage)
    {
        if (canBeDamaged)
        {
            // Resets the interval
            canBeDamaged = false;
            time = 0;

            // Take damage
            health = health - damage;

            // Play Sound
            audioManager.Play("hurt");
        }
    }
}
