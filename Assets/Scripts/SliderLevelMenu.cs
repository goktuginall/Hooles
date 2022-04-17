using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderLevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject scrollbar;
    [SerializeField] private AudioSource ButtonSound;
    private float scrollvalue, distance;
    private float[] values;
    private int pageNumb;
    private bool CheckReturn;
    void Start()
    {
        scrollvalue = 0;
        pageNumb = 0;
    }

    public void OncekiSayfa()
    {
        if (pageNumb > 0)
        {
            pageNumb -= 1;
            scrollvalue = values[pageNumb];
        }
    }

    public void SonrakiSayfa()
    {
        if (pageNumb < values.Length - 1)
        {
            pageNumb += 1;
            scrollvalue = values[pageNumb];
        }
    }

    void Update()
    {
        values = new float[this.gameObject.transform.childCount];
        distance = 1f / (values.Length - 1f);
        for(int i = 0; i < values.Length; i++)
        {
            values[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollvalue = scrollbar.gameObject.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < values.Length; i++)
            {
                if (scrollvalue < values[i] + (distance / 2) && scrollvalue > values[i] - (distance / 2))
                {
                    scrollbar.gameObject.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.gameObject.GetComponent<Scrollbar>().value, values[i], 0.15f);
                    pageNumb = i;
                }
            }
        }
        if (CheckReturn)
        {
            if (!ButtonSound.isPlaying)
            {
                SceneManager.UnloadSceneAsync("LevelSelectedScene");
            }
        }
    }

    public void RtrnHomeScreen()
    {
        CheckReturn = true;
    }
}
