using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private Transform cursor;

    private Rigidbody2D rb;

    private Quaternion rotation;
    private Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handles movement & rotation
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = cursorPos;
        
        Vector2 direction = cursor.transform.position - rb.transform.position;
        direction.Normalize();

        rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void FixedUpdate()
    {
        // Applies movement & rotation
        rb.velocity = movement * moveSpeed;
        rb.SetRotation(rotation);
    }
}
