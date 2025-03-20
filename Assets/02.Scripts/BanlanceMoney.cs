using TMPro;
using UnityEngine;

public class BanlanceMoney : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    private int balanceValue = 50000;    

    private void Start()
    {
        valueText.text = string.Format("{0:N0}", balanceValue);
    }
}
