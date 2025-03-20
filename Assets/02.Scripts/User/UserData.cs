using UnityEngine;

[System.Serializable]
public class UserData
{
    [SerializeField] private string name;
    [SerializeField] private int cash;
    [SerializeField] private int balance;

    public UserData(string name, int cash, int balance)
    {
        this.name = name;
        this.cash = cash;
        this.balance = balance;
    }    
}
