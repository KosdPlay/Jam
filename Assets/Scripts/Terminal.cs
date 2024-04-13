using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] private Door doorA;
    [SerializeField] private Door doorB;
    [SerializeField] private GameObject Button;
    private bool open;
    bool canOpen;

    private void Start()
    {
        open = false;
        Button.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = false;
        }
    }

    private void Update()
    {
        if (canOpen)
        {
            if (SelectPlayerInput.instance.isMobile == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SetIsActive();
                }
            }
            else
            {
                Button.SetActive(true);
            }
        }
        else
        {
            Button.SetActive(false);
        }
    }

    public void SetIsActive()
    {
        if (open == false)
        {
            doorA.Open();
            doorB.SetPos(true);
            open = true;
        }
        else
        {
            doorA.Close();
            doorB.SetPos(false);
            open = false;
        }

    }
}
