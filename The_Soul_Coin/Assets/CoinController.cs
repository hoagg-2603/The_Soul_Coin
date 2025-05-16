using UnityEngine;

public class CoinInBag : MonoBehaviour
{
    private Vector3 targetPosition;
    private float moveSpeed = 10f;

    private void Start()
    {
        // Lưu vị trí ban đầu
        targetPosition = transform.localPosition;
    }

    private void Update()
    {
        // Di chuyển đồng xu đến vị trí đích
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }
}