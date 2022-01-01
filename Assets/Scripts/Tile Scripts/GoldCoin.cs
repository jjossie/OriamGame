using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<CoinCollection>().RemoveCoin(this);
            Destroy(gameObject);
        }
    }

}
