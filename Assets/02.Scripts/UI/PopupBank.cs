using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;
        
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        nameText.text = GameManager.Instance.userData.name;
        cashText.text = GameManager.Instance.userData.cash.ToString("N0");
        balanceText.text = GameManager.Instance.userData.balance.ToString("N0");
    }
}
