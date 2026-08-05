using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb; //声明一个刚体组件，用于处理物理效果
    private int _speedForward = 10; //定义一个整数变量，用于存储玩家的速度值
    private int _speedSide = 5; 
    
    public void Start()
    {
         
    }

    public void Update()
    {
        
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
}
