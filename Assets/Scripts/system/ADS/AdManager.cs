using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private Script_InterstitialAd _ad;
    private void OnEnable()
    {
        ChekCell.OnEnd += Shower;
    }
    private void OnDisable()
    {
        ChekCell.OnEnd -= Shower;
    }
    private void Shower(bool win)
    {
        if(!win)
        _ad.LoadAd();
    }
}
