using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text shieldText;

    public void Start()
    {
        shieldText.text = "0";
        slider.value = 0;
    }
    public void SetMaxShield(int Shield)
    {
        slider.maxValue = Shield;
        shieldText.text = shieldText.text;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetShield(float Shield)
    {
        slider.value = Shield;
        shieldText.text = Shield.ToString();

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
