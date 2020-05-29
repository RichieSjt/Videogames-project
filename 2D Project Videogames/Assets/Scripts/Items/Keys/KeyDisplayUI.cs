using UnityEngine;
using UnityEngine.UI;

public class KeyDisplayUI : MonoBehaviour
{
    public Image[] keysIcons;

    private void Start(){
        keysIcons = GetComponentsInChildren<Image>();
    }

    private void Update() {

        if(KeysManager.key1)
        {
            var tempColor = keysIcons[0].color;
            tempColor.a = 1f;
            keysIcons[0].color = tempColor;
        }
        if(KeysManager.key2)
        {
            var tempColor = keysIcons[1].color;
            tempColor.a = 1f;
            keysIcons[1].color = tempColor;
        }
        if(KeysManager.key3)
        {
            var tempColor = keysIcons[2].color;
            tempColor.a = 1f;
            keysIcons[2].color = tempColor;
        }
    }
}