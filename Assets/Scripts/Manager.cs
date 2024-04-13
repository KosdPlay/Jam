using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject managerPref;
    private void Awake()
    {
        GameObject[] inputManger = GameObject.FindGameObjectsWithTag("Input");
        if(inputManger.Length == 0)
        {
            GameObject gameObject = Instantiate(managerPref);
        }
    }
}
