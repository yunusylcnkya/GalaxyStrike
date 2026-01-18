using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;   // Karakterin ekranda hareket hızı
    [SerializeField] private float xClampRange = 4f;     // Karakterin sağa/sola gidebileceği maksimum mesafe
    [SerializeField] private float yClampRange = 4f;     // Karakterin yukarı/aşağı gidebileceği maksimum mesafe

    [SerializeField] private float controlRollFactor = 20f;  // Sağ-sol hareketinde ne kadar yatacağını ayarlar
    [SerializeField] private float controlPitchFactor = 20f; // Yukarı-aşağı hareketinde ne kadar eğileceğini ayarlar
    [SerializeField] private float rotationSpeed = 10f;      // Dönüşün ne kadar hızlı gerçekleşeceği

    private Vector2 movement; // Karakterin hangi yöne gitmek istediğini saklar

    void Update()
    {
        // Her frame hareket ve döndürme hesaplanıyor
        ProcessTranslation(); // Karakterin pozisyonunu değiştir
        ProcessRotation();    // Karakteri hareket yönüne göre hafifçe döndür
    }

    // Input sisteminden gelen veriyi kaydediyoruz
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>(); // movement.x -> sağ/sol, movement.y -> yukarı/aşağı
    }

    // Karakteri ekranda hareket ettiren fonksiyon
    private void ProcessTranslation()
    {
        // X ekseni hareketi
        float xOffset = movement.x * controlSpeed * Time.deltaTime; // Hızı ve zamanı çarpıyoruz
        float rawXPos = transform.localPosition.x + xOffset;         // Yeni pozisyon
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange); // Ekran sınırları

        // Y ekseni hareketi
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        // Karakterin pozisyonunu güncelle
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    // Karakterin hafifçe eğilmesini/dönmesini sağlayan fonksiyon
    private void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y; // Yukarı/aşağı eğilme
        float roll = -controlRollFactor * movement.x;  // Sağ/sol yatma

        // Hedef rotasyonu oluştur
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);

        // Mevcut rotasyonu yumuşak şekilde hedef rotasyona getir
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
