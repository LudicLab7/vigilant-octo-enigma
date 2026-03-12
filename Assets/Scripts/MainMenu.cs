using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneAsset playScene;

    public void MainMenuPlayButton()
    {
        SceneManager.LoadScene(playScene.name);
    }
    public void MainMenuQuitButton()
    {
        Debug.Log("Wylaczanie!");
        Application.Quit();
    }
}
