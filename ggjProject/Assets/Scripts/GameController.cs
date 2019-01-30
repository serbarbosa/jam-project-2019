using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour { 

    public float levelMultiplier = 0.7f;
    bool gameHasEnded = false;
    public float levelTime = 0f;
    public int currLevel = 1;

    public void EndGame() {
        if (!gameHasEnded) {
            gameHasEnded = true;
            //carregar menu principal
        }
    }

    public void CompleteLevel() {
        levelTime = 0f;
        levelMultiplier *= 1.7f;
        currLevel = 2;
        Invoke("Restart", 4f);
    }

    void Restart() {
        
        gameHasEnded = false;
    }

}
