using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // �������� ����� �������
    public float lifetime = 2f; // ����� ����� �������
    public int damage = 10; // ����, ������� ������ �������

    private void Start()
    {
        // ��������� �������� ��� ����������� ������� ����� lifetime ������
        StartCoroutine(DestroyAfterLifetime());
    }

    private void Update()
    {
        // ����������� ������� ����� �� �����������
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private IEnumerator DestroyAfterLifetime()
    {
        // ����� lifetime ������, ����� ���������� ������
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� ������������ � ������� ���������
        if (other.CompareTag("Player"))
        {
            // ���� ����������� � �������, ������� ����� TakeDamage � ������
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            // ���������� ������ ����� ������������ � �������
            Destroy(gameObject);
        }
        else
        {
            Vector3 Position = transform.TransformPoint(2, 0, 0);
            Destroy(gameObject);
        }
    }
}
