using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  int MaxHealth = 500;
    [HideInInspector, Range(0f, 500f)] public float CurrentHealth;
    public int MaxShield = 250;
    [HideInInspector, Range(0f, 250f)] public float Shield = 0;
    public int timerStart = 3;
    private float timer;
    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public bool Dead = false;
    public float regen = 100f;

    private void Start()
    {
        Shield = MaxShield;
        CurrentHealth = MaxHealth;
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

    public void TakeDamage(int damage)
    {
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
            LoseShield(damage);
        }
    }
   
        

    void die()
    {
        if (!Dead)
        {
            Debug.Log("oh no you're dead");
        }
        
    }
}
