using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;      // Karakterin ateş ettiği lazerler (ParticleSystem)
    [SerializeField] RectTransform crosshair; // Ekrandaki nişangah imleci
    [SerializeField] Transform targetPoint;   // Lazerlerin bakacağı dünya noktası
    [SerializeField] float targetDistance = 100f; // Nişangahın kameradan uzaklığı

    private bool isFiring = false; // Ateş ediyor mu etmiyor mu?

    void Start()
    {
        Cursor.visible = false; // Fare imlecini gizle
    }

    void Update()
    {
        ProcessFiring();   // Ateşi yönet
        MoveCrosshair();   // Nişangahı fareye göre hareket ettir
        MoveTargetPoint();// Dünya üzerindeki hedef noktasını güncelle
        AimLasers();       // Lazerleri hedefe doğrult
    }

    // Input sisteminden gelen ateş verisi
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed; // Basılı ise ateş, değilse dur
    }

    // Lazerlerin ParticleSystem emisyonunu aç/kapat
    private void ProcessFiring()
    {
        foreach (var laser in lasers)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }

    // Nişangahı fare pozisyonuna taşı
    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    // Hedef noktasını mouse pozisyonuna göre dünya koordinatına çevir
    private void MoveTargetPoint()
    {
        // Mouse pozisyonu + hedefin kameradan uzaklığı
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    // Lazerleri hedef noktasına doğrult
    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position; // Hedefe olan yön
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);    // Bu yöne dön
            laser.transform.rotation = rotationToTarget; // Lazerin dönüşünü ayarla
        }
    }
}
