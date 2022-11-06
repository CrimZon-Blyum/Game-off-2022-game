using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0.01f,99.99f)] public float Armour = 10;
    public  int MaxHealth = 500;
    [HideInInspector] public float CurrentHealth = 500;
    public int MaxShield = 250;
    [HideInInspector] public float Shield = 250;
    public int timerStart = 3;
    private float timer;
    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public bool Dead = false;
    public float regen = 100f;

    private void Start()
    {
        CurrentHealth = 500;
        Shield = 250;
        healthBar.SetMaxHealth(MaxHealth);
        shieldBar.SetMaxShield(MaxShield);
    }

    private void Update()
    {
        if (CurrentHealth <= 0 && !Dead)
        {
            die();
            Dead = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(100);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ShieldGen());
        }

    }

    public IEnumerator ShieldGen()
    {
       
        while (Shield < MaxShield)
        {
            GainShield( regen * Time.deltaTime);
            yield return new WaitForSeconds(0.1f);

        } 
    }

    void GainShield(float ShieldGained)
    {
        if (Shield >= MaxShield)
        {
            Shield = MaxShield;
            shieldBar.SetShield(Shield);
        }
        else
        {
            Shield += ShieldGained;
            shieldBar.SetShield(Shield);
            if (Shield >= MaxShield)
            {
                Shield = MaxShield;
                shieldBar.SetShield(Shield);
            }
        }
    }

    void LoseShield(int ShieldLost)
    {
        Shield -= ShieldLost;
        shieldBar.SetShield(Shield);
    }

    public void TakeDamage(float damage)
    {
        float originalDamage = damage;
        damage = damage * ((100-Armour) / 100f);
        Debug.Log(damage + " with armour, "+ originalDamage + "without armour.");
        if (Shield <= 0)
        {
            if (CurrentHealth <= 0)
            {
                Debug.LogError("You're already dead");
            }
            else
            {
                CurrentHealth -= damage;

                healthBar.SetHealth(CurrentHealth);
            }
        }
        else
        {
            if (Shield < damage)
            {
                damage -= (int)Shield;
                Shield = 0;
                shieldBar.SetShield(Shield);
                TakeDamage(damage);
            }
            else
            {
                LoseShield((int)damage);
            }
        }
    }
   
    public void tempHealth(float amount)
    {
        CurrentHealth = CurrentHealth + amount;
        healthBar.SetHealth(CurrentHealth);
    }

    public void tempShield(int amount)
    {
        Shield = Shield + amount;
        shieldBar.SetShield(Shield);
    }

    void die()
    {
        if (!Dead)
        {
            Debug.Log("oh no you're dead");
        }
        
    }
}
