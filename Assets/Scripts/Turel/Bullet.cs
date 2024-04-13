using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // Скорость полёта снаряда
    public float lifetime = 2f; // Время жизни снаряда
    public int damage = 10; // Урон, который снаряд наносит

    private void Start()
    {
        // Запустить корутину для уничтожения снаряда через lifetime секунд
        StartCoroutine(DestroyAfterLifetime());
    }

    private void Update()
    {
        // Перемещение снаряда вперёд по направлению
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private IEnumerator DestroyAfterLifetime()
    {
        // Ждать lifetime секунд, затем уничтожить снаряд
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Обработка столкновения с другими объектами
        if (other.CompareTag("Player"))
        {
            // Если столкнулись с игроком, вызвать метод TakeDamage у игрока
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            // Уничтожить снаряд после столкновения с игроком
            Destroy(gameObject);
        }
        else
        {
            Vector3 Position = transform.TransformPoint(2, 0, 0);
            Destroy(gameObject);
        }
    }
}
