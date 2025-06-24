using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollectible : MonoBehaviour
{
    public int numberOfCoins = 0; //Cualquier script puede leer el valor pero solo este setea el valor.

    public UnityEvent<CoinCollectible> OnCoinsCollected;
    public void CoinsCollected(int coinValue)
    {
        numberOfCoins += coinValue;
        OnCoinsCollected.Invoke(this);
    }
}
