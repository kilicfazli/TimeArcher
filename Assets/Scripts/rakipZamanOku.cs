using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public AudioClip destroySound;
    public float destroyDelay = 0.2f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("zamanOku"))
        {
            // LevelTimer scriptini bul ve süreyi artýr
            LevelTimer levelTimer = FindObjectOfType<LevelTimer>();
            if (levelTimer != null)
            {
                levelTimer.AddTime(10f); // Süreyi 10 saniye artýr
            }

            // zamanOku nesnesini yok et
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("rakip"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}