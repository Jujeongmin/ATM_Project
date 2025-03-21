using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI sendErrorText;

    public GameObject buttons;
    public GameObject deposit;
    public GameObject withdraw;
    public GameObject send;
    public GameObject lack;
    public GameObject sendError;

    public TMP_InputField depositInputField;
    public TMP_InputField withdrawInputField;
    public TMP_InputField sendTargetInput;
    public TMP_InputField sendMoneyInput;

    void Start()
    {
        Refresh();
        buttons.SetActive(true);
        deposit.SetActive(false);
        withdraw.SetActive(false);
        lack.SetActive(false);
        send.SetActive(false);
        sendError.SetActive(false);
    }

    public void Refresh()
    {
        nameText.text = GameManager.Instance.userData.name;
        cashText.text = GameManager.Instance.userData.cash.ToString("N0");
        balanceText.text = GameManager.Instance.userData.balance.ToString("N0");
    }

    public void DepositBtnOnClick()
    {
        deposit.SetActive(true);
        buttons.SetActive(false);
    }

    public void WithdrawBtnOnClick()
    {
        withdraw.SetActive(true);
        buttons.SetActive(false);
    }

    public void SendBtnOnClick()
    {
        send.SetActive(true);
        buttons.SetActive(false);
    }

    public void SendRealBtn()
    {
        if (string.IsNullOrEmpty(sendTargetInput.text) ||
            string.IsNullOrEmpty(sendMoneyInput.text) ||
            !int.TryParse(sendMoneyInput.text, out int value) || value <= 0)
        {
            sendError.SetActive(true);
            sendErrorText.text = "입력 정보를 확인해주세요.";
        }
        else if (GameManager.Instance.userData.balance < value)
        {
            sendError.SetActive(true);
            sendErrorText.text = "잔액이 부족합니다.";
        }
        else
        {
            UserData targetUserData = GameManager.Instance.LoadData(sendTargetInput.text);

            if (targetUserData == null)
            {
                sendError.SetActive(true);
                sendErrorText.text = "대상이 없습니다.";                
            }

            GameManager.Instance.userData.balance -= value;

            targetUserData.balance += value;

            GameManager.Instance.SaveData();
            GameManager.Instance.SaveDataForUser(targetUserData);
            Refresh();

            sendError.SetActive(true);
            sendErrorText.text = "송금이 완료되었습니다.";
        }
    }

    public void BackBtnOnClick()
    {
        deposit.SetActive(false);
        withdraw.SetActive(false);
        send.SetActive(false);
        buttons.SetActive(true);
    }

    public void DepositCashOnClick(int value)
    {
        if (GameManager.Instance.userData.cash >= value)
        {
            GameManager.Instance.userData.cash -= value;
            GameManager.Instance.userData.balance += value;
            Refresh();
            GameManager.Instance.SaveData();
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
                GameManager.Instance.SaveData();
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

    public void SendErrorOKBut()
    {
        sendError.SetActive(false);
    }

    public void WithdrawCashOnClick(int value)
    {
        if (GameManager.Instance.userData.balance >= value)
        {
            GameManager.Instance.userData.cash += value;
            GameManager.Instance.userData.balance -= value;
            Refresh();
            GameManager.Instance.SaveData();
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
                GameManager.Instance.SaveData();
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
