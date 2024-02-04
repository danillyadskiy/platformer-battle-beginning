using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private AudioSource _audioSource;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _audioSource.Play();
            _bag.AddCoin();
            Destroy(coin.gameObject);
        }
    }
}
