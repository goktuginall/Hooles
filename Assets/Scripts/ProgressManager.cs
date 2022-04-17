using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] GameObject LoadingCanvas, LevelsCanvas;
    [SerializeField] Slider SliderBar;
    private int CheckLoad, SceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        CheckLoad = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckLoad == 1)
        {
            LevelsCanvas.SetActive(false);
            LoadingCanvas.SetActive(true);
            StartCoroutine(LoadScene());
        }
        else
        {
            LevelsCanvas.SetActive(true);
            LoadingCanvas.SetActive(false);
        }
    }

    public void ProgressVarible(int sm, int cl)
    {
        SceneNumber = sm;
        CheckLoad = cl;
    }

    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Lvl" + SceneNumber.ToString(), LoadSceneMode.Single);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            SliderBar.value = progress;
            yield return null;
        }
    }
}
