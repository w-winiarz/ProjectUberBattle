using UnityEngine;
using Xenia.ColorPicker;  // namespace z paczki

public class ColorPickerToggle : MonoBehaviour
{
    public ColorPicker colorPicker;   // tu przeciągniesz prefab pickera

    private bool isOpen = false;

    // ta metoda będzie wywoływana przez przycisk
    public void ToggleColorPicker()
    {
        if (isOpen)
        {
            colorPicker.Close();
            isOpen = false;
        }
        else
        {
            colorPicker.Open();
            isOpen = true;
        }
    }
}