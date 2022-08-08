using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    int activeSceneID = -1;

    private void Awake()
    {
        instance = this;
    }
    public void LoadScene(int sceneID)
    {
        if (activeSceneID != -1)
        {
            SceneManager.UnloadSceneAsync(activeSceneID);
        }

        StartCoroutine(LoadSceneCO(sceneID));
    }

    IEnumerator LoadSceneCO(int sceneID)
    {
        activeSceneID = sceneID;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneID));
    }


}
