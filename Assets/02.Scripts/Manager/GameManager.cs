using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

            userData = new UserData("¡÷¡§πŒ", 100000, 50000);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
