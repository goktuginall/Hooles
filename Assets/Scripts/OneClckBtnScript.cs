using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class OneClckBtnScript : MonoBehaviour
{
    [SerializeField]
    private Sprite OpenImg, CloseImg;
    public static int BtnStatus;
    private Image thisObjImage;
    [SerializeField]
    private GameObject[] SoundObj;
    private string path = "Assets/GameAssest/sfx.txt";
    private string InPath;

    void Start()
    {
        thisObjImage = this.gameObject.GetComponent<Image>();
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                InPath = reader.ReadLine();
            }
            reader.Close();
        }
        if (InPath == "Acik")
        {
            thisObjImage.sprite = OpenImg;
            BtnStatus = 0;
        }
        else if (InPath == "Kapali")
        {
            thisObjImage.sprite = CloseImg;
            BtnStatus = 1;
        }
    }

    public void ButonClickScript()
    {
        if (BtnStatus == 1)
        {
            BtnStatus = 0;
            thisObjImage.sprite = OpenImg;
            for (int i = 0; i < SoundObj.Length; i++)
            {
                SoundObj[i].gameObject.GetComponent<AudioSource>().mute = false;
            }
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Acik");
            writer.Close();
        }
        else if (BtnStatus == 0)
        {
            BtnStatus = 1;
            thisObjImage.sprite = CloseImg;
            for (int i = 0; i < SoundObj.Length; i++)
            {
                SoundObj[i].gameObject.GetComponent<AudioSource>().mute = true;
            }
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Kapali");
            writer.Close();
        }
    }
}
