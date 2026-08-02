using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed = 500;
    
    public void Start()
    {
        Debug.Log("测试游戏开始。");  
    }

    
    public void Update()
    {
        Debug.Log("测试游戏更新。");
    }
}
