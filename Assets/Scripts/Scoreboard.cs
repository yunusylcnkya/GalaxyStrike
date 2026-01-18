using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText; // Ekranda skoru gösteren TextMeshPro bileşeni

    int score = 0; // Oyuncunun mevcut skoru

    // Skoru artırmak için çağrılan metod
    public void IncreaseScore(int amount)
    {
        score += amount; // Skoru belirtilen miktarda artır
        scoreboardText.text = score.ToString(); // TextMeshPro'ya yeni skoru yaz
    }
}
