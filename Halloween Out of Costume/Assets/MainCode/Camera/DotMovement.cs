using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour //������� 50 ������� �� ������, �����
{
    public float moveSpeed = 2f;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        if (rb2D != null)
        {
            Debug.Log("Rigidbody2D ������� ������!");
        }
        else
        {
            Debug.LogWarning("Rigidbody2D �� ������ �� �������.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(moveInput * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = velocity;
    }
}
