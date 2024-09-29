using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private string GameScene;
    [SerializeField] private string MenuScene;

    public void RestartGame()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(MenuScene);
    }
}
