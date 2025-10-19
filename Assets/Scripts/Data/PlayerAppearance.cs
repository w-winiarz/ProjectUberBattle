using UnityEngine;

[System.Serializable]
public class PlayerAppearance
{
    public int hairIndex = 0;
    public Color hairColor = Color.white;

    // zapisz dane do PlayerPrefs
    public void Save()
    {
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetFloat("HairColorR", hairColor.r);
        PlayerPrefs.SetFloat("HairColorG", hairColor.g);
        PlayerPrefs.SetFloat("HairColorB", hairColor.b);
        PlayerPrefs.SetFloat("HairColorA", hairColor.a);   // 🔸 dodane zapisywanie alfy
        PlayerPrefs.Save();

        Debug.Log($"[PlayerAppearance] Zapisano: index {hairIndex}, kolor {hairColor}");
    }

    // odczytaj dane z PlayerPrefs
    public void Load()
    {
        hairIndex = PlayerPrefs.GetInt("HairIndex", 0);

        float r = PlayerPrefs.GetFloat("HairColorR", 1f);
        float g = PlayerPrefs.GetFloat("HairColorG", 1f);
        float b = PlayerPrefs.GetFloat("HairColorB", 1f);
        float a = PlayerPrefs.GetFloat("HairColorA", 1f);  // 🔸 odczyt alfy (domyślnie 1 = pełna nieprzezroczystość)

        hairColor = new Color(r, g, b, a);

        Debug.Log($"[PlayerAppearance] Wczytano: index {hairIndex}, kolor {hairColor}");
    }

    public void SetAppearance(int index, Color color)
    {
        hairIndex = index;
        hairColor = color;
    }
}