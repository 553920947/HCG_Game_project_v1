using System.Collections;
using System.Collections.Generic; //导入System.Collections.Generic命名空间，用于使用泛型集合
using UnityEngine;
using NUnit.Framework; //导入NUnit.Framework命名空间，用于编写单元测试

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb; //声明一个刚体组件，用于处理物理效果
    [SerializeField] private SpawnGroup _spawnGroup;
    [SerializeField] private Transform _bulletSpawnPistol; //声明一个变换组件，用于存储子弹的生成位置 
    [SerializeField] private GameObject _bulletPrefab; //声明一个游戏对象，用于存储子弹的预制体

    [SerializeField] private List<WeaponData> _availableWeapons; // 声明一个列表，用于存储可用的武器数据
    [SerializeField] private Transform _gunPosition; // 声明一个变换组件，用于存储枪的位置

    private GameObject _activeWeaponInstance; // 声明一个游戏对象，用于存储当前激活的武器实例

    private int _speedForward = 10; //定义一个整数变量，用于存储玩家的速度值
    private int _speedSide = 5; 
    
    public void Start()
    {
        StartCoroutine(nameof(BulletSpawn));
        if (GameManager.CurrentWeaponData == null)
        {
            WeaponToEquip(_availableWeapons[0]);
        }
        else
        {
            WeaponToEquip(GameManager.CurrentWeaponData);
        }

        GameManager.OnWeaponChanged += WeaponToEquip;
    }

    public void AddClone(int number)
    {
        // Debug.Log("玩家数量：" + number.NumberOfPlayers); //输出玩家数量
        if (_spawnGroup != null)
        {
            _spawnGroup.CreateNewPlayer(number);
        }
        
        
    }

    public void WeaponToEquip(WeaponData weapon)
    {
        if (_activeWeaponInstance != null)
        {
            Destroy(_activeWeaponInstance); // 销毁当前激活的武器实例
        }
        GameManager.CurrentWeaponData = weapon;

        _activeWeaponInstance = Instantiate(weapon.WeaponPrefab, _gunPosition); // 在枪的位置生成新的武器实例
    }

    
    public void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speedForward * Time.fixedDeltaTime); //使玩家沿着Z轴正方向移动，移动的距离为_speedForward * Time.fixedDeltaTime

        if (Input.GetKey(KeyCode.A))
        {
            GoLeft(); //调用GoLeft方法，使玩家能够向左移动
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GoRight(); //调用GoRight方法，使玩家能够向右移动
        }
        
        
    }

    private void GoLeft()
    {
        transform.Translate(Vector3.left * _speedSide * Time.fixedDeltaTime); //使玩家沿着X轴负方向移动，移动的距离为_speedSide * Time.fixedDeltaTime
    }

    private void GoRight()
    {
        transform.Translate(Vector3.right * _speedSide * Time.fixedDeltaTime); //使玩家沿着X轴正方向移动，移动的距离为_speedSide * Time.fixedDeltaTime
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     Gate_Result number = other.GetComponent<Gate_Result>();
    // }

     

    private IEnumerator BulletSpawn()
    {
        yield return new WaitForSeconds(1);
        GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPistol.position, Quaternion.identity);
        Destroy(bullet, 5);
        StartCoroutine(nameof(BulletSpawn));
    }
}








// using System.Collections;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     [SerializeField] private Rigidbody _rb; //声明一个刚体组件，用于处理物理效果
//     [SerializeField] private SpawnGroup _spawnGroup;
//     [SerializeField] private Transform _bulletSpawnPistol; //声明一个变换组件，用于存储子弹的生成位置 
//     [SerializeField] private GameObject _bulletPrefab; //声明一个游戏对象，用于存储子弹的预制体
//     private int _speedForward = 5; //定义一个整数变量，用于存储玩家的速度值
//     private int _speedSide = 5; 
    
//     public void Start()
//     {
//         StartCoroutine(nameof(BulletSpawn));
//     }

//     public void Update() 
//     {
        
//     }

    
//     public void FixedUpdate()
//     {
//         transform.Translate(Vector3.forward * _speedForward * Time.fixedDeltaTime); //使玩家沿着Z轴正方向移动，移动的距离为_speedForward * Time.fixedDeltaTime

//         if (Input.GetKey(KeyCode.A))
//         {
//             GoLeft(); //调用GoLeft方法，使玩家能够向左移动
//         }
//         else if (Input.GetKey(KeyCode.D))
//         {
//             GoRight(); //调用GoRight方法，使玩家能够向右移动
//         }
        
        
//     }

//     private void GoLeft()
//     {
//         transform.Translate(Vector3.left * _speedSide * Time.fixedDeltaTime); //使玩家沿着X轴负方向移动，移动的距离为_speedSide * Time.fixedDeltaTime
//     }

//     private void GoRight()
//     {
//         transform.Translate(Vector3.right * _speedSide * Time.fixedDeltaTime); //使玩家沿着X轴正方向移动，移动的距离为_speedSide * Time.fixedDeltaTime
//     }

//     private void OnTriggerEnter(Collider other) // 引用OnTriggerEnter方法，用于处理玩家与其他对象的碰撞事件
//     {
//         Gate_Result number = other.GetComponent<Gate_Result>();  //获取与其他对象碰撞的Gate_Result组件
//         Debug.Log("玩家数量：" + number.NumberOfPlayers); //输出玩家数量
//         if (_spawnGroup != null)
//         {
//             _spawnGroup.CreateNewPlayer();
//         }
        
//     }   

//     private IEnumerator BulletSpawn()
//     {
//         yield return new WaitForSeconds(1);
//         GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPistol.position, Quaternion.identity);
//         Destroy(bullet, 5);
//         StartCoroutine(nameof(BulletSpawn));
//     }
// }
