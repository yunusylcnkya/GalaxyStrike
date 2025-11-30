using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject laser;

    private bool isFiring = false;


    void Update()
    {
        ProcessFiring();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }


    private void ProcessFiring()
    {

        var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
        emmissionModule.enabled = isFiring;
    }
}
