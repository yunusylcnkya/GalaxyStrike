using TMPro;
using UnityEngine;

/*
BU SCRIPT NE YAPIYOR?
---------------------
Bu kod, ekranda çıkan diyalogları (konuşmaları) kontrol eder.

- Bir dizi (timelineTextLines) hazır konuşma satırı var
- Bu satırlar sırayla ekranda gösteriliyor
- NextDialogueLine() çağrıldığında bir sonraki satır ekrana gelir
*/

public class DialogLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines; // Diyalog satırları
    [SerializeField] TMP_Text dialogueText;      // Ekranda yazacak metin alanı

    int currentLine = 0; // Şu an hangi satır gösteriliyor

    public void NextDialogueLine()
    {
        // Bir sonraki satıra geç
        currentLine++;
        // Yeni satırı ekrana yaz
        dialogueText.text = timelineTextLines[currentLine];
    }
}
