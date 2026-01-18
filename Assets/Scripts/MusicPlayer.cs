using UnityEngine;

/*
BU SCRIPT NE YAPIYOR?
---------------------
Bu kod oyundaki müziğin çalmasını sağlar ve oyun sahneleri değişse bile aynı müziğin devam etmesini sağlar.
- Oyunda sadece **bir tane müzik çalar**.
- Yeni sahne yüklense bile müzik kesilmez.
*/

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        // Oyunda kaç tane MusicPlayer olduğunu sayıyoruz
        int numOfMusicPlayer = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        if (numOfMusicPlayer < 1)
        {
            // Eğer hiç MusicPlayer yoksa bu nesneyi yok et
            Destroy(gameObject);
        }
        else
        {
            // Eğer varsa, sahneler değişse bile yok olmasın
            DontDestroyOnLoad(gameObject);
        }
    }
}
