using UnityEngine;
using UnityEngine.UI;

public class KeyDisplayUI : MonoBehaviour
{
    public Image[] keysIcons;

    private void Start(){
        keysIcons = GetComponentsInChildren<Image>();
    }

    private void Update() {

        if(KeysController.key1)
        {
            var tempColor = keysIcons[1].color;
            tempColor.a = 1f;
            keysIcons[1].color = tempColor;
        }
        else if(KeysController.key2)
        {
            var tempColor = keysIcons[2].color;
            tempColor.a = 1f;
            keysIcons[2].color = tempColor;
        }
        else if(KeysController.key3)
        {
            var tempColor = keysIcons[3].color;
            tempColor.a = 1f;
            keysIcons[3].color = tempColor;
        }
    }
}