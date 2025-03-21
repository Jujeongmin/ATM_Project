using TMPro;
using UnityEngine;

public class PopupLogin : MonoBehaviour
{
    public GameObject signUpPanel;
    public GameObject errorPanel;
    public GameObject loginErrorPanel;

    public TMP_InputField idInput;
    public TMP_InputField nameInput;
    public TMP_InputField psInput;
    public TMP_InputField psConfirmInput;
    public TMP_InputField idLoginInput;
    public TMP_InputField psLoginInput;

    public TextMeshProUGUI errorText;
    public TextMeshProUGUI loginErrorText;

    void Start()
    {
        signUpPanel.SetActive(false);
        errorPanel.SetActive(false);
        loginErrorPanel.SetActive(false);
    }

    public void OpenSignUpPage()
    {
        signUpPanel.SetActive(true);
    }

    public void SignUpPageDown()
    {
        signUpPanel.SetActive(false);
    }

    public void CompleteSignUp()
    {
        if (string.IsNullOrWhiteSpace(idInput.text) ||
            string.IsNullOrWhiteSpace(nameInput.text) ||
            string.IsNullOrWhiteSpace(psInput.text) ||
            string.IsNullOrWhiteSpace(psConfirmInput.text))
        {
            errorPanel.SetActive(true);
            errorText.text = "ID �� Ȯ�����ּ���.";
        }
        else if (psInput.text != psConfirmInput.text)
        {
            errorPanel.SetActive(true);
            errorText.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
        }
        else
        {
            GameManager.Instance.userData = new UserData(nameInput.text, 100000, 50000, idInput.text, psInput.text);
            GameManager.Instance.SaveData();
            signUpPanel.SetActive(false);
        }
    }

    public void OKBtnOnClick()
    {
        errorPanel.SetActive(false);
    }

    public void LoginBtnOnClick()
    {
        if (string.IsNullOrWhiteSpace(idLoginInput.text) ||
            string.IsNullOrWhiteSpace(psLoginInput.text))
        {
            loginErrorPanel.SetActive(true);
            loginErrorText.text = "���̵� Ȥ�� ��й�ȣ�� �Է����ּ���.";
        }          
        else if (!GameManager.Instance.LoadData(idLoginInput.text))
        {
            loginErrorPanel.SetActive(true);
            loginErrorText.text = "ȸ���� �������� �ʽ��ϴ�.";
        }
        else if(GameManager.Instance.userData.password != psLoginInput.text)
        {
            loginErrorPanel.SetActive(true);
            loginErrorText.text = "��й�ȣ�� �ùٸ��� �ʽ��ϴ�.";
        }
        else
        {
            //print($"�α��� �Ϸ� {GameManager.Instance.userData.name}");
            UIManager.Instance.popupBank.SetActive(true);
            UIManager.Instance.popupLogin.SetActive(false);
        }
    }

    public void LoginErrorBtn()
    {
        loginErrorPanel.SetActive(false);
    }
}
