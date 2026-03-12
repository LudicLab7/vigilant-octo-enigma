using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Initializer : MonoBehaviour
{
    public SceneAsset loadingScreenScene;
    public SceneAsset mainMenuScene;

    [SerializeField] private List<SceneTask> taskList;

    void Start()
    {
        SceneManager.LoadScene(loadingScreenScene.name);
        foreach (var task in taskList)
        {
            task.Init();
        }
        SceneManager.LoadScene(mainMenuScene.name);
    }
}
