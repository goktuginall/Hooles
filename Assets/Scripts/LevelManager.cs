using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private string _LvlName;
    private int[] ScorePeiderList = new int[3];
    private int ComplateScore, ComplateStarScore, LvlScoreCalct, StarScoreCalct, TotalScore, CalculateSpeed, CalctHearth, AlrtBtnIsActive, MenuStatusChck, CheckNextLvl;
    private HoleDetectSystem _LvlCpmltSystem;
    private BombScript _checkthebomb;
    private AudioSource CalculateSfx;
    [SerializeField] private AudioSource SuccesRingSfx, BallSound;
    [SerializeField] private int LevelID, NextLevelID;
    public string SvDataPath;
    public int GameLvlScore, GameStarScore;
    [SerializeField] private Text ScoreTextField, StarScoreTextField, LvlCompltScoreText, HeartScoreTextField, HeartAlertTextField, LvlAlrtTextfield;
    [SerializeField] private Canvas RtryAlert, LvlCpmltAlert;
    [SerializeField] private CamBlur CameraBlur;
    [SerializeField] private GameObject _LvlCpmltDtctObj, RetryLvlDtctObj, PauseMenu, LoadingCanvas;
    [SerializeField] private Sprite[] StarsSprite = new Sprite[4];
    [SerializeField] private RectTransform StarsObj;
    [SerializeField] private Button NextBtn, RetryBtn;
    [SerializeField] private ProgressSystem progress;
    [SerializeField] private List<GameObject> Canvases;

    private void Awake()
    {
        LvlAlrtTextfield.text = "Bölüm " + LevelID.ToString();
    }

    private void Start()
    {
        CheckNextLvl = 0;
        AlrtBtnIsActive = 0;
        CalculateSfx = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        _LvlCpmltSystem = _LvlCpmltDtctObj.gameObject.GetComponent<HoleDetectSystem>();
        _checkthebomb = RetryLvlDtctObj.gameObject.GetComponent<BombScript>();
        if (_LvlCpmltSystem.LvlCmpltSystem == 1)
        {
            Complate();
        }
        else if (_checkthebomb.checkbombanim == 1)
        {
            RestartLevel(1);
        }
        else if (_checkthebomb.checkbombanim == 0)
        {
            RestartLevel(0);
        }
        if (CheckNextLvl == 1)
        {
            CameraBlur.ChangeBlurValue(0, 0);
            LoadingCanvas.SetActive(true);
            foreach (GameObject cnvs in Canvases)
            {
                cnvs.SetActive(false);
            }
            progress.ProgressFunction(_LvlName);
        }
    }

    public void SaveThisLevel()
    {
        GameLvlScore = LvlScoreCalct;
        GameStarScore = ComplateStarScore;
        SvDataPath = "/svlvl" + LevelID + ".cw";
        SvLdDatSystem.SavedLevel(this);
    }

    public void NextSaveLevel()
    {
        GameLvlScore = 0;
        GameStarScore = 0;
        SvDataPath = "/svlvl" + NextLevelID + ".cw";
        SvLdDatSystem.SavedLevel(this);
    }

    private void Complate()
    {
        BallSound.mute = enabled;
        CameraBlur.ChangeBlurValue(10, 1);
        LvlCpmltAlert.gameObject.SetActive(true);
        Time.timeScale = 0;
        int.TryParse(ScoreTextField.text, out ComplateScore);
        int.TryParse(StarScoreTextField.text, out ComplateStarScore);
        TotalScore = ComplateScore * (ComplateStarScore + 1);
        if (TotalScore > ComplateScore)
        {
            if (!CalculateSfx.isPlaying)
            {
                CalculateSfx.Play();
            }
            if (LvlScoreCalct < TotalScore)
            {
                LvlScoreCalct += 11;
                LvlCompltScoreText.text = LvlScoreCalct.ToString();
            }
        }
        else if (LvlScoreCalct < ComplateScore)
        {
            if (!CalculateSfx.isPlaying)
            {
                CalculateSfx.Play();
            }
            LvlScoreCalct += 11;
            LvlCompltScoreText.text = LvlScoreCalct.ToString();
        }
        if (LvlScoreCalct > TotalScore - 20)
        {
            StarsCalculate();
            CalculateSfx.Stop();
        }
    }

    private void StarsCalculate()
    {
        SaveThisLevel();
        CalculateSpeed = 180;
        ScorePeiderList[0] = (CalculateSpeed * 1) / 3;
        ScorePeiderList[1] = (CalculateSpeed * 2) / 3;
        ScorePeiderList[2] = (CalculateSpeed * 3) / 3;
        if (StarScoreCalct < CalculateSpeed)
        {
            StarScoreCalct += 1;
            if (ComplateStarScore == 1)
            {
                if (StarScoreCalct > ScorePeiderList[0])
                {
                    StarsObj.gameObject.GetComponent<Image>().sprite = StarsSprite[1];
                    NextBtn.gameObject.SetActive(true);
                    AlrtBtnIsActive = 1;
                    NextSaveLevel();
                    if (!SuccesRingSfx.isPlaying)
                    {
                        SuccesRingSfx.Play();
                    }
                }
            }
            else if (ComplateStarScore == 2)
            {
                if (StarScoreCalct > ScorePeiderList[0])
                {
                    StarsObj.gameObject.GetComponent<Image>().sprite = StarsSprite[1];
                    if (!SuccesRingSfx.isPlaying)
                    {
                        SuccesRingSfx.Play();
                    }
                }
                if (StarScoreCalct > ScorePeiderList[1])
                {
                    StarsObj.gameObject.GetComponent<Image>().sprite = StarsSprite[2];
                    NextBtn.gameObject.SetActive(true);
                    AlrtBtnIsActive = 1;
                    NextSaveLevel();
                    if (!SuccesRingSfx.isPlaying)
                    {
                        SuccesRingSfx.Play();
                    }
                }
            }
            else if (ComplateStarScore == 3)
            {
                if (StarScoreCalct > ScorePeiderList[0])
                {
                    StarsObj.gameObject.GetComponent<Image>().sprite = StarsSprite[1];
                    if (!SuccesRingSfx.isPlaying)
                    {
                        SuccesRingSfx.Play();
                    }
                }
                if (StarScoreCalct > ScorePeiderList[1])
                {
                    StarsObj.gameObject.GetComponent<Image>().sprite = StarsSprite[2];
                    if (!SuccesRingSfx.isPlaying)
                    {
                        SuccesRingSfx.Play();
                    }
                }
                if (StarScoreCalct >= ScorePeiderList[2])
                {
                    StarsObj.gameObject.GetComponent<Image>().sprite = StarsSprite[3];
                    NextBtn.gameObject.SetActive(true);
                    AlrtBtnIsActive = 1;
                    NextSaveLevel();
                    if (!SuccesRingSfx.isPlaying)
                    {
                        SuccesRingSfx.Play();
                    }
                }
            }
        }
    }

    private void RestartLevel(int RstrtValue)
    {
        if (RstrtValue == 1)
        {
            CameraBlur.ChangeBlurValue(10, 1);
            RtryAlert.gameObject.SetActive(true);
            Time.timeScale = 0;
            HeartAlertTextField.text = HeartScoreTextField.text;
            int.TryParse(HeartScoreTextField.text, out CalctHearth);
            BallSound.mute = true;
            if (CalctHearth > 0)
            {
                RetryBtn.gameObject.SetActive(true);
            }
            else
            {
                RetryBtn.gameObject.SetActive(false);
            }
        }
        else
        {
            CameraBlur.ChangeBlurValue(0, 0);
            RtryAlert.gameObject.SetActive(false);
            Time.timeScale = 1f;
            BallSound.mute = false;
        }
    }

    public void NextScene()
    {
        if (AlrtBtnIsActive == 1)
        {
            NextLevelFunc("Lvl" + NextLevelID.ToString());
        }
    }

    public void RepeatScene()
    {
        if (AlrtBtnIsActive == 1)
        {
            NextLevelFunc("Lvl" + LevelID.ToString());
        }
    }

    public void ReturnHomeScene()
    {
        if (AlrtBtnIsActive == 1)
        {
            SceneManager.LoadScene("FirstScreen", LoadSceneMode.Single);
        }
    }

    public void OpenMenu()
    {
        MenuStatusChck++;
        if (MenuStatusChck == 1)
        {
            PauseMenu.gameObject.SetActive(true);
        }
        else if (MenuStatusChck == 2)
        {
            PauseMenu.gameObject.SetActive(false);
            MenuStatusChck = 0;
        }
    }

    public void CloseLevel()
    {
        SceneManager.LoadScene("FirstScreen", LoadSceneMode.Single);
    }
    public void NextLevelFunc(string lvlname)
    {
        CheckNextLvl = 1;
        _LvlName = lvlname;
    }
}
