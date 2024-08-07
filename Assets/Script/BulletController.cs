using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkBehaviour))]
public class BulletController : NetworkBehaviour
{
    public float speed = 10f; // Tốc độ của đạn
    public float lifetime = 5f; // Thời gian sống của đạn trước khi tự hủy

    void Start()
    {
        // Hủy đối tượng này sau khi hết thời gian sống
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Di chuyển đạn sang phải theo trục X
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}