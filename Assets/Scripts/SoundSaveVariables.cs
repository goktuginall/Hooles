using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundSaveVariables
{
    public int MusicVariables;
    public int SfxVariables;
    public SoundSaveVariables(SoundManager sm)
    {
        MusicVariables = sm.MusicVariable;
        SfxVariables = sm.SfxVariable;
    }
}
