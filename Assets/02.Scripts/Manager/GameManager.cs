using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;

    string path;
    string filename = "save.json";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

            path = Application.persistentDataPath + "/";
            LoadData(1);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SaveData(int slot)
    {
        string data = JsonUtility.ToJson(userData, true);
        File.WriteAllText(path + filename + slot, data);
        Debug.Log($"����: {data}");
    }

    public void LoadData(int slot)
    {
        string fullPath = path + filename + slot;

        if (File.Exists(fullPath))
        {
            string data = File.ReadAllText(fullPath);
            userData = JsonUtility.FromJson<UserData>(data);
            Debug.Log($"�ε�: {data}");
        }
        else
        {
            print("����� �����Ͱ� �����ϴ�.");
            userData = new UserData("������", 100000, 50000, "wnwjdals", "1234");
            SaveData(slot);
            print(fullPath);
        }
    }
}
