using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerInput : MonoBehaviour
{

    public static SelectPlayerInput instance;

    public bool isMobile;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

}
