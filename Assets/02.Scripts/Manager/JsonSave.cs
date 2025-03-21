using System.IO;
using UnityEngine;

public class JsonSave : MonoBehaviour
{
    private void Start()
    {
        UserData userData = GameManager.Instance.userData;        

        string json = JsonUtility.ToJson(userData, true);
        Debug.Log("Json: " + json);

        SaveJsonToFile(json);

        LoadJsonFromFile();
    }

    void SaveJsonToFile(string json)
    {
        string path = Application.persistentDataPath + "/userData.json";

        File.WriteAllText(path, json);
        Debug.Log("Saved Json to: " + path);
    }

    void LoadJsonFromFile()
    {
        string path = Application.persistentDataPath + "/userData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log("Loaded Json: " + json);

            UserData userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("Loaded UserData - Name: " + userData.name
                + "Cash: " + userData.cash + "Banlance: " + userData.balance);
        }
        else
        {
            Debug.LogError("No saved data found at: " + path);
        }
    }
}
