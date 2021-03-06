using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    private int currentHealth;
    public int CurrentHealth => currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    private void applyDamage(int damage)
    {
        currentHealth -= damage;
    }
}
