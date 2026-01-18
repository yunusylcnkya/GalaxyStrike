using UnityEngine;

/*
BU SCRIPT NE YAPIYOR?
---------------------
Bu kod, bir obje başka bir şeye çarptığında ne olacağını kontrol eder.

- Eğer çarpışma olursa:
    - Oyunu yeniden başlatır (level reset)
    - Patlama veya kırılma efekti çıkarır (destroyedVFX)
    - Çarpan objeyi sahneden yok eder
*/

public class ColllisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyedVFX; // Patlama/kırılma efekti
    GameSceneManager gameSceneManager;

    void Start()
    {
        // Sahnedeki GameSceneManager’ı bul
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Bir şeyle çarpıştıysa:
        gameSceneManager.ReloadLevel(); // Level’ı yeniden başlat
        Instantiate(destroyedVFX, transform.position, Quaternion.identity); // Efekti sahneye koy
        Destroy(gameObject); // Kendini yok et
    }
}
