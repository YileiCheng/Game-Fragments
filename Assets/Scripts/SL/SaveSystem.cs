using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        string path = Application.persistentDataPath + "/player.save";

        PlayerData data = new PlayerData(player);
        
        BinaryFormatter formatter = new BinaryFormatter();

        var json = JsonUtility.ToJson(data);
        using (FileStream stream = File.Open(path, FileMode.Create))
        {
            formatter.Serialize(stream, json);
        }
    }

    public static void LoadPlayer(Player player)
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            XmlSerializer xml = new XmlSerializer(typeof(PlayerData));

            using (FileStream stream = File.OpenRead(path))
            {

                PlayerData playerdata = JsonUtility.FromJson<PlayerData>((string)bf.Deserialize(stream));

                player.inventory = playerdata.inventory;
                Vector3 position;
                position.x = playerdata.position[0];
                position.y = playerdata.position[1];
                position.z = playerdata.position[2];
                player.transform.position = position;
            }
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }

}