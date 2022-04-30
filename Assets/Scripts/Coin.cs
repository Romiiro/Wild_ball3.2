using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collectedEffect;
    [SerializeField] private ScoreSystem _scoreSystem;
    
    private void Start() {
        _scoreSystem.RegisterCoin();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Collect();
        }
    }

    private void Collect() {
        _scoreSystem.CollectCoin();
        Instantiate(_collectedEffect, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
