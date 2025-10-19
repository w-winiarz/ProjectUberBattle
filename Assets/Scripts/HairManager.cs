using UnityEngine;
using Xenia.ColorPicker;
using UnityEngine.SceneManagement;

public class HairManager : MonoBehaviour
{
    [Header("Renderer włosów")]
    public SpriteRenderer hairRenderer;

    [Header("Dostępne fryzury")]
    public Sprite[] hairOptions;

    [Header("Color Picker (opcjonalnie)")]
    public ColorPicker colorPicker;

    private int currentIndex;
    private Color currentColor = Color.white;

    void Start()
    {
        // podłącz picker
        if (colorPicker != null)
            colorPicker.ColorChanged.AddListener(OnColorChanged);

        // inicjalne ustawienie
        UpdateHairVisual();
    }

    // wybór kolejnej fryzury
    public void NextHair()
    {
        if (hairOptions.Length == 0) return;
        currentIndex = (currentIndex + 1) % hairOptions.Length;
        UpdateHairVisual();
    }

    // wybór poprzedniej fryzury
    public void PreviousHair()
    {
        if (hairOptions.Length == 0) return;
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = hairOptions.Length - 1;
        UpdateHairVisual();
    }

    // zmiana koloru z color pickera
    private void OnColorChanged(Color newColor)
    {
        currentColor = newColor;
        UpdateHairVisual();
    }

    // aktualizacja sprite + koloru na ekranie
    private void UpdateHairVisual()
    {
        hairRenderer.sprite = (hairOptions.Length > 0) ? hairOptions[currentIndex] : null;
        hairRenderer.color = currentColor;
    }

    // zapis wyglądu i przejście do następnej sceny
    public void ConfirmAndContinue(string nextScene)
    {
        Debug.Log($"Zapisuję: index {currentIndex}, kolor {currentColor}");//test
        PlayerDataManager.Instance.appearance.SetAppearance(currentIndex, currentColor);
        SceneManager.LoadScene(nextScene);
    }

    // funkcje pomocnicze do odczytu
    public int CurrentHairIndex => currentIndex;
    public Color CurrentHairColor => currentColor;

}
