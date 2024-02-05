using UnityEngine;

public class MedicalKitCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out MedicalKit medicalKit))
        {
            _player.RestoreHealth();
            Destroy(medicalKit.gameObject);
        }
    }
}
