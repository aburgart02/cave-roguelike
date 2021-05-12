using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public Health health;

	public void SetHealth()
	{
		slider.maxValue = health.maxHealth;
		slider.value = health.health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    public void Update()
    {
        if (health != null && Input.GetKeyDown(KeyCode.Space))
        {
			health.TakeDamage(20);
        }
    }
}