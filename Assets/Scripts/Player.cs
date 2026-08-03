using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb; //声明一个刚体组件，用于处理物理效果
    private int _speed = 300; //定义一个整数变量，用于存储玩家的速度值
    
    public void Start()
    {
         
    }

    
    public void FixedUpdate()
    {
        _rb.AddForce(0, 0, _speed * Time.deltaTime); //在每个固定更新帧中，向刚体施加一个沿Z轴方向的力，使玩家前进，力的大小为_speed * Time.deltaTime，确保在不同帧率下速度保持一致

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
        _rb.AddForce(-_speed * Time.deltaTime, 0, 0); //向刚体施加一个沿X轴负方向的力，使玩家向左移动，力的大小为_speed * Time.deltaTime
    }

    private void GoRight()
    {
        _rb.AddForce(_speed * Time.deltaTime, 0, 0); //向刚体施加一个沿X轴正方向的力，使玩家向右移动，力的大小为_speed * Time.deltaTime
    }   
}
