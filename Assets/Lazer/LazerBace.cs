using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBace : MonoBehaviour
{
    [SerializeField] protected GameObject lazer;
    [SerializeField] protected bool is_time;
    [SerializeField] protected float time_on;
    [SerializeField] protected float time_off;

    // Start is called before the first frame update
    void Start()
    {
        if (is_time)
        {
            StartCoroutine(OffOn());
        }
    }

    private IEnumerator OffOn()
    {
        while (true)
        {
            lazer.SetActive(true);
            yield return new WaitForSeconds(time_on);
            lazer.SetActive(false);
            yield return new WaitForSeconds(time_off);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}