using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    private CoinCollectible coinCollectible;
    public TextMeshProUGUI coinText;

    [SerializeField] private AudioClip coinCollectedSound;
    private AudioSource audioSource;

    void Start()
    {
        if (coinText == null)
            coinText = GetComponent<TextMeshProUGUI>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Configurar sonido 2D para UI
        audioSource.spatialBlend = 0f;
    }

    public void UpdateCoinText(CoinCollectible coinCollectible)
    {
        coinText.text = " " + coinCollectible.numberOfCoins;

        if (coinCollectedSound != null)
        {
            audioSource.PlayOneShot(coinCollectedSound);
        }
    }
}