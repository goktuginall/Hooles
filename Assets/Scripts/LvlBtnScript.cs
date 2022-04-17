using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlBtnScript : MonoBehaviour
{
    public string LoadSvData;
    private int activescore, LvlStarsNumber;
    [SerializeField] private Sprite starlvlZero, starlvl1, starlvl2, starlvl3, LvlBtnLock, LvlBtnUnlck;
    [SerializeField] private GameObject ScoreObj, StarsObj;
    [SerializeField] private int DefaultLvlNumber;
    [SerializeField] private ProgressManager progManager;
    void Start()
    {
        LoadSvData = "/svlvl" + DefaultLvlNumber + ".cw";
        string path = Application.persistentDataPath + LoadSvData;
        if (File.Exists(path))
        {
            VariableData data = SvLdDatSystem.LoadedLevel(this);
            this.gameObject.GetComponent<Image>().sprite = LvlBtnUnlck;
            this.gameObject.GetComponent<Button>().enabled = true;
            StarsObj.gameObject.SetActive(true);
            ScoreObj.gameObject.SetActive(true);
            activescore = data.DataLvlSocre;
            LvlStarsNumber = data.DataStarScore;
            ScoreObj.gameObject.GetComponent<Text>().text = activescore.ToString();
            if (LvlStarsNumber == 1)
            {
                StarsObj.gameObject.GetComponent<Image>().sprite = starlvl1;
            }
            else if (LvlStarsNumber == 2)
            {
                StarsObj.gameObject.GetComponent<Image>().sprite = starlvl2;
            }
            else if (LvlStarsNumber == 3)
            {
                StarsObj.gameObject.GetComponent<Image>().sprite = starlvl3;
            }
        }
        else
        {
            if (DefaultLvlNumber == 1)
            {
                StarsObj.gameObject.GetComponent<Image>().sprite = starlvlZero;
                ScoreObj.gameObject.GetComponent<Text>().text = "0";
            }
            else if (DefaultLvlNumber == 2 || DefaultLvlNumber == 3)
            {
                StarsObj.gameObject.GetComponent<Image>().sprite = starlvlZero;
                ScoreObj.gameObject.GetComponent<Text>().text = "0";
                this.gameObject.GetComponent<Button>().enabled = false;
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = LvlBtnLock;
                StarsObj.gameObject.SetActive(false);
                ScoreObj.gameObject.SetActive(false);
                this.gameObject.GetComponent<Button>().enabled = false;
            }
        }
    }

    public void GotoLevel()
    {
        progManager.ProgressVarible(DefaultLvlNumber, 1);
    }
}
