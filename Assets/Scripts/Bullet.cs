using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        // 修复：保留生成时的飞行方向，叠加默认90度俯仰角，使弹体模型朝向实际飞行方向
        Vector3 flyDirection = transform.forward; // 获取子弹的飞行方向 
        transform.rotation = Quaternion.LookRotation(flyDirection) * Quaternion.Euler(90, 0, 0); // 将子弹的旋转设置为飞行方向

        // 防御：若子弹没有Rigidbody，补一个运动学刚体，保证OnCollisionEnter碰撞检测必定生效
        //（Unity物理规则：碰撞双方至少一方需要Rigidbody，否则不会触发碰撞事件）
        if (GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // 运动学刚体不影响Translate移动
            rb.useGravity = false;
        }
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
            // 修复：用GetComponentInParent查找敌人脚本，兼容碰撞体挂在敌人子物体上的情况
            Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.HitEnemy(); // 调用敌人死亡协程
            }
        }
        Destroy(gameObject); // 枪射出的子弹碰撞到敌人后销毁，敌人后销毁
    }
}








// using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     private void Start()
//     {
//         // 修复：保留生成时的飞行方向，叠加默认90度俯仰角，使弹体模型朝向实际飞行方向
//         Vector3 flyDirection = transform.forward; // 获取子弹的飞行方向 
//         transform.rotation = Quaternion.LookRotation(flyDirection) * Quaternion.Euler(90, 0, 0); // 将子弹的旋转设置为飞行方向
//     }

//     private void Update()
//     {
//         // 子弹速度和持续时间
//         // 说明：物体绕X轴旋转90度后，弹体正前方对应本地方向 Vector3.up，沿其移动保持直线飞行
//         transform.Translate(Vector3.up * 50 * Time.deltaTime);
//     }

//     private void OnCollisionEnter(Collision collision) // 枪射出的子弹碰撞到敌人后销毁
//     {
//         if (collision.gameObject.tag == "Enemy") // 枪射出的子弹碰撞时检查标签Enemy
//         {
//             Enemy enemy = collision.gameObject.GetComponent<Enemy>(); // 获取敌人组件
//             enemy.HitEnemy(); // 调用敌人死亡协程
//         }
//         Destroy(gameObject); // 枪射出的子弹碰撞到敌人后销毁，敌人后销毁
//     }
// }





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
