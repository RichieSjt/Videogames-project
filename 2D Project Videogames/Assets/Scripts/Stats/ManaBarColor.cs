using UnityEngine;
using System;

public class ManaBarColor : MonoBehaviour
{
    public SpriteRenderer barSprite;
    public Color fire = new Color(1f, 0.39f, 0f);
    public Color air = new Color(0.8f, 0.8f, 0.8f);
    public Color electricity = new Color(1f, 0.98f, 0f);

    public static ManaBarColor instance;

    private void Start()
    {
        instance = this; 
        barSprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeBarColor(int currentMagic)
    {
        if(currentMagic == 1)
            barSprite.color = fire;
        if(currentMagic == 2)
            barSprite.color = air;
        if(currentMagic == 3)
            barSprite.color = electricity;
    }

}