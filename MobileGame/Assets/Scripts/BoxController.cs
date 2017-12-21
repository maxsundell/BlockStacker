using UnityEngine;
using System;

public class BoxController : MonoBehaviour 
{

    float moveSpeed = 3;

    Rigidbody2D rb;
    public static event Action OnScoreStart;
    public static event Action OnGameOver;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Border Bounce
        if (transform.position.x >= Camera.main.orthographicSize * Camera.main.aspect + 1.5f)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        if (transform.position.x <= -Camera.main.orthographicSize * Camera.main.aspect - 1.5f)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            rb.gravityScale = 1;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            if (tag == "StartBox")
            {
                if (OnScoreStart != null)
                {
                    OnScoreStart();
                }
            }
            else
            {
                if (OnGameOver != null)
                {
                    OnGameOver();
                }
            }
        }

        if (transform.position.y >= Camera.main.transform.position.y)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.y += .4f;
            Camera.main.transform.position = pos;
            Camera.main.orthographicSize += .4f;
        }
    }

}
