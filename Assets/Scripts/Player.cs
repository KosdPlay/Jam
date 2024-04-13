using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private Image lineBar;
    [SerializeField] private int hp = 100;

    private int hpRecoveryRate = 5; // скорость восстановления хп в секунду
    private int hpRecoveryCooldown = 3; // время между восстановлениями хп
    private bool isHpRecovering = false;

    [SerializeField] private bool isHpRecoveryEnabled;

    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
        UpdateUI();
        if (hp <= 0)
        {
            Debug.Log("Всё");
            Death();
        }

    }

    private void Start()
    {

        isHpRecoveryEnabled = false;
    }


    private void Death()
    {
        SceneManager.LoadScene("game");
    }

    private void HpRecovery()
    {
        if (isHpRecovering)
        {
            hp += hpRecoveryRate;
            UpdateUI();
        }

        if (hp >= 100)
        {
            hp = 100;
            UpdateUI();
            isHpRecovering = false;
        }
    }

    private void Update()
    {
        if (!isHpRecovering && hp <= 100 && isHpRecoveryEnabled == true)
        {
            isHpRecovering = true;
            InvokeRepeating("HpRecovery", hpRecoveryCooldown, hpRecoveryCooldown);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }

    }

    private void UpdateUI()
    {
        lineBar.fillAmount = (float)hp / 100;
    }

    public void EnableHpRecovery()
    {
        isHpRecoveryEnabled = true;
    }

    public int GetHP()
    {
        return hp;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
