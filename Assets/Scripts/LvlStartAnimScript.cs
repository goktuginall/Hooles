using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlStartAnimScript : MonoBehaviour
{
    [SerializeField] private int AnimExitCheck;
    [SerializeField] private GameObject AnimCanvas, StartGameObj, TextObj;
    private void Start()
    {
        if (SceneManager.sceneCount < 2)
        {
            this.gameObject.GetComponent<Animator>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            TextObj.SetActive(true);
            StartGameObj.SetActive(false);
        }
    }
    private void Update()
    {
        if (AnimExitCheck == 1)
        {
            AnimCanvas.gameObject.SetActive(false);
            StartGameObj.SetActive(true);
        }
    }
}
