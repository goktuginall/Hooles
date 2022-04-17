using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressSystem : MonoBehaviour
{
    [SerializeField] private Slider slider;
    IEnumerator ProgressCorotune(string sN)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sN, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            slider.value = progress;
            yield return null;
        }
    }
    public void ProgressFunction(string SceneName)
    {
        StartCoroutine(ProgressCorotune(SceneName));
    }
}
