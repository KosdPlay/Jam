using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour

{
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float fire_rate;
    bool pl_in_zone = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gos)
            player = (go);

        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            Debug.Log("Пельмени");
            if (pl_in_zone)
            {
                if (player.transform.position.x < transform.position.x)
                {
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
                }
                else
                {
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 180f));
                }
                yield return new WaitForSeconds(fire_rate);
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Обработка столкновения с другими объектами
        if (other.CompareTag("Player"))
        {
            
            pl_in_zone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Обработка столкновения с другими объектами
        if (other.CompareTag("Player"))
        {
            pl_in_zone = false;
        }
    }
}

