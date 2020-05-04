using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthSystem healthSystem;

    private void Start()
    {
        transform.Find("Bar").localScale = new Vector3(1, 0.2018672f);
    }

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        //Using events to increase performance instead of using update every frame
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 0.2018672f);
    }

}
