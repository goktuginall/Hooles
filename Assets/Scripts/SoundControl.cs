using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SoundControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] SoundObj;
    private string path = "Assets/GameAssest/sfx.txt";
    private string pathMusic = "Assets/GameAssest/music.txt";
    private string InPath, InPathMusic;
    private AudioSource BgMusic;
    // Start is called before the first frame update
    void Start()
    {
        BgMusic = this.gameObject.GetComponent<AudioSource>();
        if (!BgMusic.isPlaying)
        {
            BgMusic.Play();
        }
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                InPath = reader.ReadLine();
            }
            reader.Close();
        }

        if (File.Exists(pathMusic))
        {
            StreamReader MusicReader = new StreamReader(pathMusic);
            while (!MusicReader.EndOfStream)
            {
                InPathMusic = MusicReader.ReadLine();
            }
        }

        if (InPath == "Acik")
        {
            for (int i = 0; i < SoundObj.Length; i++)
            {
                SoundObj[i].gameObject.GetComponent<AudioSource>().mute = false;
            }
        }
        else if (InPath == "Kapali")
        {
            for (int i = 0; i < SoundObj.Length; i++)
            {
                SoundObj[i].gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
