using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthText;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        healthText.text = health.ToString() + "/" + slider.maxValue.ToString();
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        health = Mathf.Round(health * 100) / 100;

        if (health <= 0)
        {
            health = 0;
        }
        slider.value = health;
        healthText.text = health.ToString() + "/" + slider.maxValue.ToString();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
