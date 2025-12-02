using UnityEngine;

public class ColllisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyedVFX;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
