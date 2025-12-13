using UnityEngine;

public class ColllisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyedVFX;
    GameSceneManager gameSceneManager;
    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
