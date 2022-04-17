using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarterSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject OptionChildMenu;
    private void Update()
    {

    }
    public void SelectedOption()
    {
        if (OptionChildMenu != null)
        {
            bool isActive = OptionChildMenu.activeSelf;
            OptionChildMenu.SetActive(!isActive);
        }
    }
    public void LevelSelected()
    {
        SceneManager.LoadScene("LevelSelectedScene", LoadSceneMode.Additive);
    }
    public void InstagramURL()
    {
        Application.OpenURL("https://www.instagram.com/goktuginl/");
    }

    public void FacebookURL()
    {
        Application.OpenURL("https://www.facebook.com/forbidden.king");
    }

    public void ExitScene()
    {

    }
}
