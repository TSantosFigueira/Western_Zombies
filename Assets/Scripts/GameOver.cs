using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject gameOverCanvas;
    public Text score;
    public ScoreManager scoreManager;
   // public Text highScore;

    private Sounds manager;

	void Start () {
        manager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<Sounds>();
	}
	
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            manager.playSound("PlayerDeath", 0.5f);
            gameOverCanvas.SetActive(true);
            score.text = PlayerScore.localScore.ToString();
            scoreManager.AddScore("player", PlayerScore.localScore);
            scoreManager.DisplayLeaderboard();
            FadeIn();
            PauseManager.isPaused = true;
            gameObject.transform.position = new Vector2(-10, -10);
        }
    }

    IEnumerator FadeIn ()
    {
        CanvasGroup canvas = gameOverCanvas.GetComponent<CanvasGroup>();
        canvas.alpha = 0;

        while(canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime;
            yield return null;
        }
    }
}
