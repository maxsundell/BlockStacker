using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour 
{
	
	public Text scoreText;

    private void Update()
    {
        scoreText.text = "SCORE\n<b><size=80>" + GameManager.score + "</size></b>";
    }

}
