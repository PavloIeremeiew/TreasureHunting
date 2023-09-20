using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MainSave 
{
    public int Coin;
    public MainSave(int coin)
    {
        Coin = coin;
    }
    public MainSave()
    {
        Coin = 0;
    }
    public static MainSave operator +(MainSave a, MainSave b)
    {
        MainSave mainSave=new MainSave();
        mainSave.Coin = a.Coin+b.Coin;

        return mainSave;
    }
    public static MainSave operator -(MainSave a, MainSave b)
    {
        MainSave mainSave = new MainSave();
        mainSave.Coin = a.Coin - b.Coin;

        return mainSave;
    }

}
