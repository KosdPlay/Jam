using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour

{
    [SerializeField] protected Player player;
    [SerializeField] protected int damage;
    [SerializeField] protected float fire_rate;
    bool pl_in_zone = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gos)
            player = (go.GetComponent<Player>());

        
    }

    private void OnEnable()
    {
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            if (pl_in_zone)
            {
                player.TakeDamage(damage);
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

