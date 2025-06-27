using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleLogicScript : MonoBehaviour {
    public void startGame() {
        SceneManager.LoadScene("FlappyBirdScene");
    }

    public void quitGame() {
        #if UNITY_STANDALONE
                Application.Quit(); // Quits the player
        #endif

        #if UNITY_EDITOR
                EditorApplication.isPlaying = false; // Stops Play Mode in the editor
        #endif
    }
}
