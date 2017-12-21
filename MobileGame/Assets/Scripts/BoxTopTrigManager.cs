using UnityEngine;
using System;

public class BoxTopTrigManager : MonoBehaviour 
{

    public static event Action OnScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            OnScore();
        }
    }

}
