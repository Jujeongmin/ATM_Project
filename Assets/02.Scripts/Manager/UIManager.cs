using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject popupBank;
    public GameObject popupLogin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

            popupBank.SetActive(false);
            popupLogin.SetActive(true);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
