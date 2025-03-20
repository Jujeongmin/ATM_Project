using System;

[Serializable]
public class UserData
{
    private string userName;
    private int curMoney;
    private int balanceMoney;

    public UserData(string userName, int curMoney, int balanceMoney)
    {
        this.userName = userName;
        this.curMoney = curMoney;
        this.balanceMoney = balanceMoney;
    }    
}
