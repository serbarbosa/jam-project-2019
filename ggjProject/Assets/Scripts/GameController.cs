using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour { 

    public float levelMultiplier = 0.7f;
    bool gameHasEnded = false;

    public void EndGame() {
        if (!gameHasEnded) {
            gameHasEnded = true;
            //carregar menu principal
        }
    }

    public void CompleteLevel() {
        levelMultiplier *= 1.7f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameHasEnded = false;
    }

}
