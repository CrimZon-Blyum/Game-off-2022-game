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
        shieldText.text = "250/250";
    }
    public void SetMaxShield(int Shield)
    {
        slider.maxValue = Shield;
        slider.value = Shield;
        shieldText.text = shieldText.text;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetShield(float Shield)
    {
        Shield = Mathf.Round(Shield * 100f) / 100f;
        slider.value = Shield;
        shieldText.text = Shield.ToString() + "/" + slider.maxValue.ToString();

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
