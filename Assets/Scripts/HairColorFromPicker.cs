using UnityEngine;
using Xenia.ColorPicker; // <- ważne: przestrzeń nazw assetu

public class HairColorFromPicker : MonoBehaviour
{
    [SerializeField] private ColorPicker colorPicker;   // referencja do pickera
    [SerializeField] private SpriteRenderer hairRenderer; // włosy do farbowania

    private void Awake()
    {
        // Subskrybujemy event – za każdym razem, jak gracz zmieni kolor w pickerze
        colorPicker.ColorChanged.AddListener(SetHairColor);
    }

    private void SetHairColor(Color newColor)
    {
        hairRenderer.color = newColor; // farbowanie włosów
    }
}