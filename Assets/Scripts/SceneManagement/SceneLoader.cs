using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour {

    public Slider loadingSlider;
    public TextMeshProUGUI progressText;

    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        if (!SceneWithNameExitst(sceneName))
            yield break;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        canvas.enabled = true;

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.SetSlider(progress);
            progressText.text = (int)(progress * 100f) + "%";

            yield return null;
        }

        canvas.enabled = false;
    }

    bool SceneWithNameExitst(string name)
    {
        if(SceneUtility.GetBuildIndexByScenePath(name) >= 0)
        {
            return true;
        }
        else
        {
            Debug.LogError("scene " + name + " is not in the build!");
            return false;
        }
    }
}