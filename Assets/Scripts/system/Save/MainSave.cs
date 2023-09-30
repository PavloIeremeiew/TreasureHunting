using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MainSave 
{
    public int Coin=0;
    public int SecondTrys = 0;
    public MainSave(int coin)
    {
        Coin = coin;
    }
    public MainSave(int coin, int secondTrys)
    {
        Coin = coin;
        SecondTrys = secondTrys;
    }

    public static MainSave SecondTrysSet(int secondTrys)
    {
        MainSave s = new MainSave();
        s.SecondTrys = secondTrys;
        return s;
    }
    public MainSave()
    {

    }
    public static MainSave operator +(MainSave a, MainSave b)
    {
        MainSave mainSave=new MainSave();
        mainSave.Coin = a.Coin+b.Coin;
        mainSave.SecondTrys = a.SecondTrys + b.SecondTrys;

        return mainSave;
    }
    public static MainSave operator -(MainSave a, MainSave b)
    {
        MainSave mainSave = new MainSave();
        mainSave.Coin = a.Coin - b.Coin;
        mainSave.SecondTrys = a.SecondTrys - b.SecondTrys;

        return mainSave;
    }

}
