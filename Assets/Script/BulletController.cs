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
    }
    public void DestroyBullet(){
        // Destroy(gameObject, lifetime);

        NetworkObject.Despawn();
    }

    void Update()
    {
        // Di chuyển đạn sang phải theo trục X
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if(lifetime<0)
            if(IsServer)
                DestroyBullet();
    }
}