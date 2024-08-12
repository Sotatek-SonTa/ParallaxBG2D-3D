using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkBehaviour))]
public class GunController : NetworkBehaviour
{
    public GameObject bulletPrefab; // Prefab của đạn
    public Transform firePoint; // Vị trí mà đạn sẽ được bắn ra
    public float bulletSpeed = 20f; // Tốc độ của đạn

    void Update()
    {
        if(!IsOwner) return;
        if (Input.GetMouseButtonDown(0)) // Kiểm tra nếu chuột trái được nhấn
        {
            ShootServerRpc(transform.position);
        }
    }
    [ServerRpc]
    void ShootServerRpc(Vector3 position)
    {
        // Tạo một instance của đạn tại firePoint
        // GameObject bullet = Instantiate(bulletPrefab, position, firePoint.rotation);
        var bullet = ObjectPool.Instance.poolOjbects[bulletPrefab].Get();
        bullet.transform.position = position;
        bullet.Spawn();
        // bullet.GetComponent<NetworkObject>().Spawn();
        // Thêm lực đẩy vào đạn để nó di chuyển
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}