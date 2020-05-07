using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    public ManaSystem manaSystem;

    private void Start()
    {
        transform.Find("Bar").localScale = new Vector3(1, 0.2018672f);
    }

    public void Setup(ManaSystem manaSystem)
    {
        this.manaSystem = manaSystem;

        manaSystem.OnManaChanged += ManaSystem_OnManaChanged;
    }

    private void ManaSystem_OnManaChanged(object sender, System.EventArgs e)
    {
        //Using events to increase performance instead of using update every frame
        transform.Find("Bar").localScale = new Vector3(manaSystem.GetManaPercent(), 0.2018672f);
    }
}
