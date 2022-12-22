using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startGameScene;

    // When clicked, this will take the player to the first level
    public void startGame()
    {
        SceneManager.LoadScene(startGameScene);
    }

    // When clicked, this will take the player to the settings screen
    public void settings()
    {

    }

    // When clicked, this will exit the game
    public void quitGame()
    {
        Application.Quit();
    }
}
