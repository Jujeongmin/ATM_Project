using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;

    string path;
    string filenamePrefix = "save_";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            path = Application.persistentDataPath + "/";
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SaveData()
    {
        string fullPath = path + filenamePrefix + userData.id + ".json";
        string data = JsonUtility.ToJson(userData, true);
        File.WriteAllText(fullPath, data);
        Debug.Log($"저장: {fullPath}");
    }

    public UserData LoadData(string userId)
    {
        string fullPath = path + filenamePrefix + userId + ".json";

        if (!File.Exists(fullPath))
        {
            return null;
        }

        string data = File.ReadAllText(fullPath);
        return JsonUtility.FromJson<UserData>(data);
    }


    //public bool LoadData(string userId)
    //{
    //    string fullPath = path + filenamePrefix + userId + ".json";

    //    if (!File.Exists(fullPath))
    //    {
    //        print("저장된 데이터가 없습니다.");
    //        return false;
    //    }

    //    string data = File.ReadAllText(fullPath);
    //    userData = JsonUtility.FromJson<UserData>(data);
    //    Debug.Log($"로드: {data}");
    //    return true;
    //}

    public void SaveDataForUser(UserData userData)
    {
        string fullPath = path + filenamePrefix + userData.id + ".json";
        string data = JsonUtility.ToJson(userData, true);
        File.WriteAllText(fullPath, data);
    }
}
