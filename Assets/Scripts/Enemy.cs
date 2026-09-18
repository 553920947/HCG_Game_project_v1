using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _bulletSpawnPistol; // 敌人子弹生成位置
    [SerializeField] private GameObject _bulletPrefab; // 敌人子弹预制体
    private bool _isDead = false;

    private void Start()
    {
        StartCoroutine(nameof(BulletSpawn)); // 敌人出生后开始生成子弹
    }
    public void FixedUpdate()
    {
        if (!_isDead)
        {
            transform.Translate(Vector3.forward * 5 * Time.fixedDeltaTime); // 敌人速度和持续时间
        }
        
    }

    public void HitEnemy()
    {
        if (_isDead) // 已死亡则忽略重复命中，避免重复启动死亡协程
        {
            return;
        }
        StartCoroutine(nameof(DeadEnemy));
    }

    public IEnumerator DeadEnemy()
    {
        _isDead = true;
        // 防御：Animator未赋值时不崩溃，死亡销毁流程仍会继续执行
        if (_animator != null)
        {
            _animator.SetBool("IsDead", true); // 播放死亡动画
        }
        yield return new WaitForSeconds(2); // 敌人死亡后等待2秒
        Destroy(gameObject); // 敌人死亡后销毁
    }

    private IEnumerator BulletSpawn()
    {
        yield return new WaitForSeconds(1); // 敌人生成子弹的间隔时间
        // 修复：子弹沿敌人自身朝向（前进方向）发射，飞向玩家
        if (!_isDead)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPistol.position, transform.rotation); // 敌人生成子弹的位置和旋转角度
            Destroy(bullet, 5); // 子弹存在时间
            StartCoroutine(nameof(BulletSpawn)); // 递归调用生成子弹
        }
    }
}







// using System.Collections;
// using TMPro;
// using Unity.VisualScripting;
// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     [SerializeField] private Animator _animator;
//     [SerializeField] private Transform _bulletSpawnPistol; // 敌人子弹生成位置
//     [SerializeField] private GameObject _bulletPrefab; // 敌人子弹预制体
//     private bool _isDead = false;

//     private void Start()
//     {
//         StartCoroutine(nameof(BulletSpawn)); // 敌人出生后开始生成子弹
//     }
//     public void FixedUpdate()
//     {
//         if (!_isDead)
//         {
//             transform.Translate(Vector3.forward * 5 * Time.fixedDeltaTime); // 敌人速度和持续时间
//         }
        
//     }

//     public void HitEnemy()
//     {
//         StartCoroutine(nameof(DeadEnemy));
//     }

//     public IEnumerator DeadEnemy()
//     {
//         _isDead = true;
//         _animator.SetBool("IsDead", true);
//         yield return new WaitForSeconds(2); // 敌人死亡后等待2秒
//         Destroy(gameObject); // 敌人死亡后销毁
//     }

//     private IEnumerator BulletSpawn()
//     {
//         yield return new WaitForSeconds(1); // 敌人生成子弹的间隔时间
//         // 修复：子弹沿敌人自身朝向（前进方向）发射，飞向玩家
//         if (!_isDead)
//         {
//             GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPistol.position, transform.rotation); // 敌人生成子弹的位置和旋转角度
//             Destroy(bullet, 5); // 子弹存在时间
//             StartCoroutine(nameof(BulletSpawn)); // 递归调用生成子弹
//         }
//     }
// }


// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     public void FixedUpdate()
//     {
//         transform.Translate(Vector3.forward * 5 * Time.deltaTime); // 敌人速度和持续时间
//     }

// }
