using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LogicScript : MonoBehaviour {
    private const string HIGH_SCORE_KEY = "HighScore";

    private bool isGameOver = false;

    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource addScoreSound;
    public AudioSource gameOverSound;
    public AudioSource backgroundMusic;

    // Use this for initialization
    void Start() {
        backgroundMusic.Play(0);
        gameOverSound.time = 0.5f; // begin playing sound at the audible part of the clip
        updateHighScore();
    }

    // Update is called once per frame
    void Update() {
        if (isGameOver) {
            if (backgroundMusic.isPlaying && backgroundMusic.pitch < 0.01) {
                backgroundMusic.Stop();
            } else if (backgroundMusic.isPlaying) {
                backgroundMusic.pitch *= 0.995f;
            }
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {
        addScoreSound.Play(0);
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame() {
        #if UNITY_STANDALONE
                Application.Quit(); // Quits the player
        #endif

        #if UNITY_EDITOR
                EditorApplication.isPlaying = false; // Stops Play Mode in the editor
        #endif
    }

    public void gameOver() {
        gameOverSound.Play(0);
        updateHighScore();
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }
    
    private void updateHighScore() {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);

        // If the new score is higher, update and save
        if (playerScore > highScore) {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, playerScore);
            PlayerPrefs.Save();
            Debug.Log("New High Score: " + playerScore);
        }

        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
