using System.Collections;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad
{
    private static readonly string playerSave = Application.persistentDataPath + "/VoxelTowerDefense.player";
    private static readonly string powerUpSave = Application.persistentDataPath + "/VoxelTowerDefense.power";
    public static void SaveData(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerSave, FileMode.Create);
        PlayerData playerData = new PlayerData(player);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static void SavePower(PowerUpData[] powerUps)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(powerUpSave, FileMode.Create);
        formatter.Serialize(stream, powerUps);
        stream.Close();
    }

    public static PowerUpData[] LoadPower(){
        if (File.Exists(powerUpSave))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(powerUpSave, FileMode.Open);
            PowerUpData[] data = formatter.Deserialize(stream) as PowerUpData[];
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Unable to load power save data in " + powerUpSave);
            Debug.LogWarning("Loading default power data.");
            PowerUpData[] data = null;
            return data;
        }
    }

    public static PlayerData LoadSave()
    {
        if (File.Exists(playerSave))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(playerSave, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Unable to load player save data in " + playerSave);
            Debug.LogWarning("Loading default player data.");
            PlayerData data = new PlayerData();
            return data;
        }
    }
}
