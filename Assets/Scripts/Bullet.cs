using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        // 优化：子弹飞行时默认角度为90度（绕X轴旋转90度，使弹体模型朝向飞行方向）
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    private void Update()
    {
        // 子弹速度和持续时间
        // 说明：物体绕X轴旋转90度后，弹体正前方对应本地方向 Vector3.up，沿其移动保持直线飞行
        transform.Translate(Vector3.up * 50 * Time.deltaTime);
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





// using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     private void Update()
//     {
//         transform.Translate(Vector3.forward * 50 * Time.deltaTime); // 子弹速度和持续时间
//     }

//     private void OnCollisionEnter(Collision collision) // 枪射出的子弹碰撞到敌人后销毁
//     {
//         if (collision.gameObject.tag == "Enemy") // 枪射出的子弹碰撞时检查标签Enemy
//         {
//             Destroy(collision.gameObject); // 枪射出的子弹碰撞到敌人后销毁
//         }
//         Destroy(gameObject); // 枪射出的子弹碰撞到敌人后销毁，敌人后销毁
//     }
// }
