using UnityEngine;

public class ApplyAppearance : MonoBehaviour
{
    public SpriteRenderer hairRenderer;
    public Sprite[] hairOptions;

    void Start()
    {
        var data = PlayerDataManager.Instance.appearance;
        hairRenderer.sprite = hairOptions[data.hairIndex];
        hairRenderer.color = data.hairColor;
    }
}