using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputer : MonoBehaviour
{
    public static event Action OnClick;
    public void Click()
    {
        OnClick?.Invoke();
    }
}
