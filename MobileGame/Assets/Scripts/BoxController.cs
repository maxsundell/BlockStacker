using UnityEngine;
using System;

public class BoxController : MonoBehaviour 
{

    float moveSpeed = 3;

    Rigidbody2D rb;
    public static event Action OnScoreStart;
    public static event Action OnGameOver;

    bool hasDropped = false;

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

        if (Input.GetMouseButtonDown(0) && !hasDropped)
        {
            rb.gravityScale = 1;
            rb.velocity = Vector2.zero;
            hasDropped = true;
        }

        if (transform.eulerAngles.z > 20 && transform.eulerAngles.z < 340 && !GameManager.gameIsOver)
        {
            OnGameOver();
            print("TRIGGERED" + transform.eulerAngles.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            if (tag == "StartBox" && !GameManager.gameIsOver)
            {
                if (OnScoreStart != null)
                {
                    OnScoreStart();
                }
            }
            else
            {
                if (OnGameOver != null && !GameManager.gameIsOver)
                {
                    OnGameOver();                    
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone") && !GameManager.gameIsOver)
        {
            OnGameOver();
            Destroy(gameObject);
        }
    }

}
