using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    public GameObject Buttons;
        
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

    public void OnClick()
    {
        //입금 버튼을 클릭하면 입금화면 켜지고 입금출금버튼 꺼지고
        //출근 버튼을 클릭하면 출금화면 켜지고 입금출금버튼 꺼지고
    }
}
