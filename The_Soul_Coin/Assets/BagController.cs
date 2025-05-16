using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [Header("Bag Settings")]
    [SerializeField] private Transform coinContainer;
    [SerializeField] private float coinSpacing = 0.1f;
    [SerializeField] private int maxCoins = 10;
    [SerializeField] private float coinMoveSpeed = 10f;

    private List<GameObject> coinsInBag = new List<GameObject>();

    public void AddCoin(GameObject coin)
    {
        if (coinContainer == null || coinsInBag.Count >= maxCoins) return;

        // Tắt physics
        if (coin.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.simulated = false;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // Tắt collider
        if (coin.TryGetComponent<Collider2D>(out var col))
        {
            col.enabled = false;
        }

        // Thêm vào danh sách
        coinsInBag.Add(coin);

        // Đặt làm con của container
        coin.transform.SetParent(coinContainer);

        // Thêm component CoinInBag
        var coinInBag = coin.AddComponent<CoinInBag>();

        // Tính toán vị trí mới
        Vector3 newPosition = CalculateCoinPosition(coinsInBag.Count - 1);
        coinInBag.SetTargetPosition(newPosition);
    }

    private Vector3 CalculateCoinPosition(int index)
    {
        // Tính toán vị trí dựa trên index
        float x = (index % 3) * coinSpacing;
        float y = (index / 3) * coinSpacing;
        return new Vector3(x, y, 0);
    }
}