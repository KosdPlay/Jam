using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPuddle : MonoBehaviour
{
    private Player player;
    private bool isDamage = true;
    private bool inZone;
    [SerializeField] private float damageSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player == null)
            {
                player = collision.GetComponent<Player>();
            }
            inZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inZone = false;
        }
    }

    private void Update()
    {
        if (inZone)
        {
            StartCoroutine(TakeDamage());
        }
    }

    private IEnumerator TakeDamage()
    {
        if (isDamage)
        {
            player.TakeDamage(1);

            StartCoroutine(ReloadTakeDamage());

            yield return null;
        }
    }

    private IEnumerator ReloadTakeDamage()
    {
        isDamage = false;

        yield return new WaitForSeconds(damageSpeed);

        isDamage = true;

    }
}
