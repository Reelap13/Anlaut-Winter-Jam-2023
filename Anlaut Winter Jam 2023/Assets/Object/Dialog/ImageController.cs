using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageController : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Sprite[] sprites;

    public void ChangeImage(string name)
    {
        text.text = name;
        image.sprite = GetSpriteByName(name);
    }

    private Sprite GetSpriteByName(string name)
    {
        foreach(Sprite sprite in sprites)
        {
            if (sprite.name == name)
                return sprite;
        }
        Debug.Log("Unknown sprite name");
        return null;
    }
}
