using UnityEngine;
using System;

public class BoxTopTrigManager : MonoBehaviour 
{

    public static event Action OnScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Box") && !GameManager.gameIsOver)
        {
            OnScore();
        }
        
        if (transform.position.y >= Camera.main.transform.position.y)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.y += .8f;
            Camera.main.transform.position = pos;
            Camera.main.orthographicSize += .8f;
        }
    }
}
