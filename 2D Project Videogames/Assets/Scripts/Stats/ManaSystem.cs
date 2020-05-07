using UnityEngine;
using System;

public class ManaSystem : MonoBehaviour
{
    public int mana;
    public int maxMana;
    public int recoveryAmount = 2;
    public float recoveryRate = 1f;
    private float currentTime = 0f;
    public event EventHandler OnManaChanged;

    private void Update(){
        //Mana recover over time
        if(Time.time >= currentTime)
        {
            RecoverMana(recoveryAmount);
            currentTime = Time.time + 1f / recoveryRate;
        }
    }

    public int GetMana()
    {
        return mana;
    }

    public float GetManaPercent()
    {
        return (float) mana / maxMana; 
    }

    public void ReduceMana(int manaReduce)
    {
        mana -= manaReduce;
        if(mana < 0)
        {
            mana = 0;
        }
        OnManaChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RecoverMana(int manaAmount)
    {
        mana += manaAmount;
        if (mana > maxMana)
            mana = maxMana;

        OnManaChanged?.Invoke(this, EventArgs.Empty);
    }
}
