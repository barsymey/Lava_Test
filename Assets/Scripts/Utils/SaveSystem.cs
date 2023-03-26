using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary> An utility for saving and loading data to filesystem. </summary>
public class SaveSystem
{
    public void SaveInventoryData(int[] data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public int[] LoadInventoryData()
    {
        string path = Application.persistentDataPath + "/game.sav";
        Debug.Log(path);
        if(!File.Exists(path))
            return new int[Enum.GetValues(typeof(ResourceType)).Length];

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        stream.Position = 0;

        int[] data = formatter.Deserialize(stream) as int[];
        stream.Close();
        return data;
    }
}
