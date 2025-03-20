using TMPro;
using UnityEngine;

public class CurMoney : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    private int curMoneyValue = 100000;

    private void Start()
    {
        valueText.text = string.Format("{0:N0}", curMoneyValue);
    }
}
