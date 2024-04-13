using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{
    [SerializeField] private GameObject currentTime;
    [SerializeField] private GameObject oldTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime.SetActive(true);
        oldTime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeTime();
        }
    }

    public void ChangeTime()
    {
        currentTime.SetActive(!currentTime.activeSelf);
        oldTime.SetActive(!currentTime.activeSelf);
    }
}
