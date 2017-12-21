using UnityEngine;

public class GameManager : MonoBehaviour 
{

    public GameObject box;

    public static int score;
    public static bool gameIsOver = false;

    private void Start()
    {
        SpawnBox(true);
        BoxController.OnScoreStart += Scored;
        BoxTopTrigManager.OnScore += Scored;
        BoxController.OnGameOver += GameOver;
    }

    private void Update()
    {
        
    }

    private void SpawnBox(bool startBlock)
    {
        Vector2 spawnPos = new Vector2(Camera.main.orthographicSize * Camera.main.aspect + 2, Camera.main.orthographicSize - 1 + Camera.main.transform.position.y);
        GameObject blockInst = Instantiate(box, spawnPos, Quaternion.identity, transform);
        if (startBlock)
        {
            blockInst.tag = "StartBox";
        }
    }

    private void Scored()
    {
        score++;
        SpawnBox(false);
    }

    private void GameOver()
    {
        gameIsOver = true;
        print("Game Over!");
    }

}
