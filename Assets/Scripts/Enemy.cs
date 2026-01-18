using UnityEngine;

/*
BU SCRIPT NE YAPIYOR?
---------------------
Bu kod bir düşmanı kontrol eder.

- Düşmanın canı (hitPoints) vardır
- Düşmana mermi veya başka şeyler çarptığında hasar alır
- Canı 0 olursa patlar, skor artar ve düşman yok olur
*/

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyedVFX; // Patlama efekti
    [SerializeField] int hitPoints = 3;          // Düşmanın canı
    [SerializeField] int scoreValue = 10;        // Öldürülünce oyuncuya verilecek puan

    Scoreboard scoreboard; // Skor tabelasına erişmek için

    void Start()
    {
        // Skor tabelasını bul
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    // Partikül (ör. mermi veya lazer) çarptığında çalışır
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        // Canı azalt
        hitPoints--;

        // Eğer can 0 veya altındaysa düşmanı yok et
        if (hitPoints <= 0)
        {
            // Skoru artır
            scoreboard.IncreaseScore(scoreValue);

            // Patlama efekti oluştur
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);

            // Düşmanı yok et
            Destroy(gameObject);
        }
    }
}
