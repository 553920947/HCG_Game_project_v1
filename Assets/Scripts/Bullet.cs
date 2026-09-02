using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.forward * 50 * Time.deltaTime); // 子弹速度和持续时间
    }

    private void OnCollisionEnter(Collision collision) // 枪射出的子弹碰撞到敌人后销毁
    {
        if (collision.gameObject.tag == "Enemy") // 枪射出的子弹碰撞时检查标签Enemy
        {
            Destroy(collision.gameObject); // 枪射出的子弹碰撞到敌人后销毁
        }
        Destroy(gameObject); // 枪射出的子弹碰撞到敌人后销毁，敌人后销毁
    }
}
