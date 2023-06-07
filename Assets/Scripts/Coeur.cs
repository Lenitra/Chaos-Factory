using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coeur : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    public Slider healthUI;

    public void TakeDamage(int damage)
    {
        updateUI();
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Partie gagnée !");
    }
    

    public void updateUI()
    {
        healthUI.value = health/maxHealth;
    }
}
