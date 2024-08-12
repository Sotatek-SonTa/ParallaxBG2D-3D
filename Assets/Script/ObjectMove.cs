using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float speed = 2f; // Tốc độ di chuyển
    public float moveTime = 2f; // Thời gian di chuyển theo một hướng
    public Vector3 direction = Vector3.right; // Hướng di chuyển (mặc định là sang phải)

    private float moveTimer;
    private bool movingForward = true;

    void Start()
    {
        moveTimer = moveTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        var player = other.gameObject.GetComponent<PlayerController>();
        player.HealthDrain();
    }
    void FixedUpdate()
    {
        moveTimer -= Time.fixedDeltaTime;

        // Di chuyển vật thể
        if (movingForward)
        {
            transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(-direction.normalized * speed * Time.fixedDeltaTime);
        }

        // Đổi hướng khi hết thời gian
        if (moveTimer <= 0f)
        {
            movingForward = !movingForward;
            moveTimer = moveTime; // Reset timer
        }
    }
}