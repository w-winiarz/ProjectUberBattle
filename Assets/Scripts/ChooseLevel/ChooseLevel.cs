using UnityEngine;
using TMPro; // Potrzebne do pracy z TextMeshPro
using UnityEngine.UI; // Potrzebne do pracy z przyciskami (Button)

public class EnemyLevelInput : MonoBehaviour
{
    // Pole do przeciągnięcia obiektu InputField w edytorze
    public TMP_InputField levelInputField;

    // ZMIANA: Zmienna do przechowywania ostatecznego poziomu.
    // Jest publiczna, więc będziesz widział jej wartość w Inspectorze.
    public int WybranyPoziomPrzeciwnika = 1; // Wartość domyślna

    void Start()
    {
        // Sprawdź, czy pole zostało przypisane w Inspectorze
        if (levelInputField == null)
        {
            Debug.LogError("Nie przypisano pola InputField do skryptu!");
            return;
        }
    }

    // ZMIANA: To jest nowa funkcja, którą wywoła nasz przycisk.
    // Musi być publiczna!
    public void AkceptujPoziom()
    {
        // Pobierz tekst z pola InputField
        string input = levelInputField.text;

        // Spróbuj przekonwertować tekst na liczbę
        if (int.TryParse(input, out int parsedLevel))
        {
            // Jeśli się udało, zapisz wynik do naszej zmiennej
            WybranyPoziomPrzeciwnika = parsedLevel;
            Debug.Log($"Zaakceptowano! Wybrany poziom przeciwnika to teraz: {WybranyPoziomPrzeciwnika}");
        }
        else
        {
            // Jeśli wpisano coś, co nie jest liczbą, lub pole jest puste
            Debug.LogWarning($"Wartość '{input}' jest nieprawidłowa. Poziom nie został zmieniony.");
        }

        // Opcjonalnie: wyczyść pole po akceptacji
        levelInputField.text = "";
    }
}