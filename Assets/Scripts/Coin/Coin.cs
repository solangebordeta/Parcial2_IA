using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CoinCollectible coinCollectible = other.GetComponent<CoinCollectible>();

        if (coinCollectible != null)
        {
            int coinValue = GetRandomCoinValue();
            coinCollectible.CoinsCollected(coinValue);

            Debug.Log("Moneda recolectada con valor: " + coinValue);

            // destruye solo esta moneda
            Destroy(gameObject);
        }
    }

    private int GetRandomCoinValue()
    {
        List<(int value, float weight)> options = new List<(int, float)>
    {
        (1, 50f), // 50% probabilidad
        (3, 30f), // 30%
        (5, 20f), // 20%
    };

        float totalWeight = 0f;
        foreach (var option in options)
            totalWeight += option.weight;

        float randomValue = Random.Range(0f, totalWeight);
        float currentSum = 0f;

        foreach (var option in options)
        {
            currentSum += option.weight;
            if (randomValue <= currentSum)
                return option.value;
        }
        return 1; // Fallback
    }
}
