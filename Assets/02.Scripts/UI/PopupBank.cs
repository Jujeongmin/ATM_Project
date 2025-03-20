using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    public GameObject Buttons;
    public GameObject Deposit;
    public GameObject Withdraw;
    public GameObject lack;

    public TMP_InputField depositInputField;
    public TMP_InputField withdrawInputField;

    void Start()
    {
        Refresh();
        Buttons.SetActive(true);
        Deposit.SetActive(false);
        Withdraw.SetActive(false);
        lack.SetActive(false);
    }

    public void Refresh()
    {
        nameText.text = GameManager.Instance.userData.name;
        cashText.text = GameManager.Instance.userData.cash.ToString("N0");
        balanceText.text = GameManager.Instance.userData.balance.ToString("N0");
    }

    public void DepositBtnOnClick()
    {
        Deposit.SetActive(true);
        Buttons.SetActive(false);
    }

    public void WithdrawBtnOnClick()
    {
        Withdraw.SetActive(true);
        Buttons.SetActive(false);
    }

    public void BackBtnOnClick()
    {
        Deposit.SetActive(false);
        Withdraw.SetActive(false);
        Buttons.SetActive(true);
    }

    public void DepositCashOnClick(int value)
    {
        if (GameManager.Instance.userData.cash >= value)
        {
            GameManager.Instance.userData.cash -= value;
            GameManager.Instance.userData.balance += value;
            Refresh();
        }
        else
        {
            lack.SetActive(true);
        }
    }

    public void CustomDepositBtnOnClick()
    {
        if (int.TryParse(depositInputField.text, out int value) && value > 0)
        {
            if (GameManager.Instance.userData.cash >= value)
            {
                GameManager.Instance.userData.cash -= value;
                GameManager.Instance.userData.balance += value;
                depositInputField.text = "";
                Refresh();
            }
            else
            {
                depositInputField.text = "";
                lack.SetActive(true);
            }
        }
        else
        {
            depositInputField.text = "";
        }
    }

    public void LackOKButtonOnClick()
    {
        lack.SetActive(false);
    }

    public void WithdrawCashOnClick(int value)
    {
        if (GameManager.Instance.userData.balance >= value)
        {
            GameManager.Instance.userData.cash += value;
            GameManager.Instance.userData.balance -= value;
            Refresh();
        }
        else
        {
            lack.SetActive(true);
        }
    }

    public void CustomWithdrawBtnOnClick()
    {
        if (int.TryParse(withdrawInputField.text, out int value) && value > 0)
        {
            if (GameManager.Instance.userData.balance >= value)
            {
                GameManager.Instance.userData.cash += value;
                GameManager.Instance.userData.balance -= value;
                withdrawInputField.text = "";
                Refresh();
            }
            else
            {
                withdrawInputField.text = "";
                lack.SetActive(true);
            }
        }
        else
        {
            withdrawInputField.text = "";
        }
    }
}
