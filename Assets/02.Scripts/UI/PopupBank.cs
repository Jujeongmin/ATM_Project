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
        //�Ա� ��ư�� Ŭ���ϸ� �Ա�ȭ�� ������ �Ա���ݹ�ư ������
        //��� ��ư�� Ŭ���ϸ� ���ȭ�� ������ �Ա���ݹ�ư ������
    }
}
