using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Sounds
{
    [SerializeField] private GameObject door;
    [SerializeField] private Transform point;
    [SerializeField] private Vector2 startPoint;
    [SerializeField] private AudioSource source;
    [SerializeField] private float speed = 1;
    private bool open;
    [SerializeField] private bool doorA;


    private void Awake()
    {
        startPoint = door.transform.position;
    }

    public void Open()
    {
        //PlaySound(sounds[0]);
        open = true;
    }

    public void Close()
    {
        //PlaySound(sounds[0]);
        open = false;
    }

    private void FixedUpdate()
    {
        if (doorA)
        {
            if (open)
            {
                door.transform.position = Vector2.MoveTowards(door.transform.position, point.position, speed * Time.deltaTime);
            }
            else
            {
                door.transform.position = Vector2.MoveTowards(door.transform.position, startPoint, speed * Time.deltaTime);
            }
        }
    }

    public void SetPos(bool open)
    {
        if (open == true)
        {
            door.transform.position = point.position;
        }
        else
        {
            door.transform.position = startPoint;
        }
    }
}
