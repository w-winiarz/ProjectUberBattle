using UnityEngine;
using Xenia.ColorPicker;  // bo prefab ma ten namespace

public class ChangeHairColor : MonoBehaviour
{
    public SpriteRenderer hairRenderer;
    public ColorPicker colorPicker; // dodajemy referencję do okienka pickera

    public void SetHairColor(Color newColor)
    {
        hairRenderer.color = newColor;
    }

    // Funkcja pod OnClick z przycisku
    public void ToggleColorPicker()
    {
        if (colorPicker.gameObject.activeSelf)
        {
            colorPicker.Close(); // chowa
        }
        else
        {
            colorPicker.Open(); // pokazuje
        }
    }
}