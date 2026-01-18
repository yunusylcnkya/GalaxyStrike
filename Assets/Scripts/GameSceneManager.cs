using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
BU SCRIPT NE YAPIYOR?
---------------------
Bu kod oyundaki sahneyi (level) yeniden başlatmak için kullanılır.
- Düşman öldüğünde veya oyuncu bir yere çarptığında çağrılabilir
- Bir süre bekledikten sonra aynı sahne tekrar yüklenir
*/

public class GameSceneManager : MonoBehaviour
{
    // Bu metod çağrıldığında sahneyi yeniden başlatır
    public void ReloadLevel()
    {
        // Coroutine başlatılır (yani sahne hemen değil, biraz bekledikten sonra tekrar açılır)
        StartCoroutine(ReloadLevelRoutine());
        Debug.Log("reload level"); // Konsola mesaj yazılır
    }

    // Coroutine: sahneyi yeniden yükleme işlemi
    private IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(2f); // 2 saniye bekle
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Şu anki sahnenin numarasını al
        SceneManager.LoadScene(currentSceneIndex); // Aynı sahneyi tekrar yükle
    }
}
