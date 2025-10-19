using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;              // tu przechowujemy globalną instancję
    public PlayerAppearance appearance = new PlayerAppearance();

    private void Awake()
    {
        // 👇 Ten log powinien się pojawić ZAWSZE przy uruchomieniu gry.
        Debug.Log("[PlayerDataManager] Awake START!");

        // sprawdź, czy już istnieje jakaś instancja
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);                  // 🍀 ten obiekt nie znika między scenami
            Debug.Log("[PlayerDataManager] Ustawiono Instance i DontDestroyOnLoad.");

            // jeśli w PlayerPrefs istnieją stare dane – załaduj je
            if (PlayerPrefs.HasKey("HairIndex"))
            {
                Debug.Log("[PlayerDataManager] Wykryto zapisane dane, ładuję Appearance...");
                appearance.Load();
            }
            else
            {
                Debug.Log("[PlayerDataManager] Nie znaleziono zapisu, tworzę nowe dane Appearance.");
            }
        }
        else
        {
            Debug.Log("[PlayerDataManager] Duplikat – niszczę ten obiekt.");
            Destroy(gameObject);                            // 🧹 usuń duplikaty przy ładowaniu następnych scen
        }

        Debug.Log("[PlayerDataManager] Awake KONIEC!");
    }

    private void Start()
    {
        // 👇 Log pomocniczy, żeby upewnić się, że manager działa po starcie
        Debug.Log($"[PlayerDataManager] Start() -> hairIndex={appearance.hairIndex}, color={appearance.hairColor}");
    }
}