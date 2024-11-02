using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour //Сумарно 50 строчек на камеру, понты
{
    public float moveSpeed = 2f;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(moveInput * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = velocity;
    }
}
