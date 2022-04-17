using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SoundManager : MonoBehaviour
{
    public int MusicVariable,SfxVariable;
    private string path;
    [SerializeField] private int SfxButtonCheck, MusicButtonCheck;
    [SerializeField] private GameObject[] MusicSoundObjects, SfxSoundObjects;
    private void Awake()
    {
        path = Application.persistentDataPath + "/Sounds.cw";
        if (File.Exists(path))
        {
            SoundSaveVariables data = SvLdDatSystem.LoadedSounds();
            MusicVariable = data.MusicVariables;
            SfxVariable = data.SfxVariables;
        }
        else
        {
            MusicVariable = 1;
            SfxVariable = 1;
        }
    }
    private void Start()
    {
        SfxControlSystem(SfxVariable);
        MusicControlSystem(MusicVariable);
    }
    private void SfxControlSystem(int value)
    {
        if (value == 0)
        {
            if (SfxSoundObjects != null)
            {
                for (int i = 0; i < SfxSoundObjects.Length; i++)
                {
                    SfxSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = true;
                }
            }
            SfxButtonCheck = 0;
            OneButtonSfx();
        }
        if (value == 1)
        {
            if (SfxSoundObjects != null)
            {
                for (int i = 0; i < SfxSoundObjects.Length; i++)
                {
                    SfxSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = false;
                }
            }
            SfxButtonCheck = 1;
            OneButtonSfx();
        }
    }
    private void MusicControlSystem(int value)
    {
        if (value == 0)
        {
            if (MusicSoundObjects != null)
            {
                for (int i = 0; i < MusicSoundObjects.Length; i++)
                {
                    MusicSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = true;
                }
            }
            MusicButtonCheck = 0;
            OneButtonMusic();
        }
        if (value == 1)
        {
            if (MusicSoundObjects != null)
            {
                for (int i = 0; i < MusicSoundObjects.Length; i++)
                {
                    MusicSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = false;
                }
            }
            MusicButtonCheck = 1;
            OneButtonMusic();
        }
    }
    public void OneButtonSfx()
    {
        SfxButtonCheck++;
        if (SfxButtonCheck == 1)
        {
            if (SfxSoundObjects != null)
            {
                for (int i = 0; i < SfxSoundObjects.Length; i++)
                {
                    SfxSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = true;
                }
            }
            SfxVariable = 0;
        }
        else if (SfxButtonCheck == 2)
        {
            if (SfxSoundObjects != null)
            {
                for (int i = 0; i < SfxSoundObjects.Length; i++)
                {
                    SfxSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = false;
                }
            }
            SfxButtonCheck = 0;
            SfxVariable = 1;
        }
    }
    public void OneButtonMusic()
    {
        MusicButtonCheck++;
        if (MusicButtonCheck == 1)
        {
            if (MusicSoundObjects != null)
            {
                for (int i = 0; i < MusicSoundObjects.Length; i++)
                {
                    MusicSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = true;
                }
            }
            MusicVariable = 0;
        }
        else if (MusicButtonCheck == 2)
        {
            if (MusicSoundObjects != null)
            {
                for (int i = 0; i < MusicSoundObjects.Length; i++)
                {
                    MusicSoundObjects[i].gameObject.GetComponent<AudioSource>().mute = false;
                }
            }
            MusicButtonCheck = 0;
            MusicVariable = 1;
        }

    }
    public void MusicButtonClick()
    {
        OneButtonMusic();
        SvLdDatSystem.SavedSounds(this);
    }
    public void SfxButtonClick()
    {
        OneButtonSfx();
        SvLdDatSystem.SavedSounds(this);
    }
    public void ClickSound()
    {
        if (!SfxSoundObjects[0].gameObject.GetComponent<AudioSource>().isPlaying)
        {
            SfxSoundObjects[0].gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
