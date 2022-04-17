using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SvLdDatSystem : MonoBehaviour
{
    public static void SavedLevel(LevelManager lm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + lm.SvDataPath;
        FileStream stream = new FileStream(path, FileMode.Create);
        VariableData data = new VariableData(lm);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static VariableData LoadedLevel(LvlBtnScript lvlbtn)
    {
        string path = Application.persistentDataPath + lvlbtn.LoadSvData;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            VariableData data = formatter.Deserialize(stream) as VariableData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    public static void SavedSounds(SoundManager sm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Sounds.cw";
        FileStream stream = new FileStream(path, FileMode.Create);
        SoundSaveVariables data = new SoundSaveVariables(sm);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SoundSaveVariables LoadedSounds()
    {
        string path = Application.persistentDataPath + "/Sounds.cw";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SoundSaveVariables data = formatter.Deserialize(stream) as SoundSaveVariables;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
