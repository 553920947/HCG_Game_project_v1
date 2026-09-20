using UnityEngine;

public class Gate_Result : MonoBehaviour
{
    [SerializeField] private GateData _gateData; // 门数据
    private bool _isProcessed = false; // 门效果是否已处理，防止克隆出的新玩家再次触发导致无限复制

    private void OnTriggerEnter(Collider other)
    {
        if (_isProcessed) // 门效果只处理一次，切断递归克隆链
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        Player player = other.GetComponent<Player>(); // 获取玩家组件
        if (player == null) // 防御：确保玩家组件存在
        {
            return;
        }

        if (_gateData == null) // 防御：缺少门数据时不处理，避免空引用
        {
            return;
        }

        _isProcessed = true; // 先标记已处理，再执行效果

        switch (_gateData.EffectType)
        {
            case GateEffectType.ClonePlayer:
                player.AddClone(_gateData.CloneNumber);
                break;
            case GateEffectType.ChangWeapon:
                player.WeaponToEquip(_gateData.WeaponToEquip);
                GameManager.UploadWeapon();
                break;
        }
    }

    public enum GateEffectType
    {
        ClonePlayer,
        ChangWeapon
    }

    [CreateAssetMenu(fileName = "GateData", menuName = "GateData")]

    public class GateData : ScriptableObject 
    {
        public GateEffectType EffectType; // 门效果类型
        public WeaponData WeaponToEquip; // 武器数据
        public int CloneNumber; // 克隆数量
    }

    // [Tooltip("门变化数量：+2生成2人，‑2删除2人")]
    // public int NumberOfPlayers;
}









// using UnityEngine;

// public class Gate_Result : MonoBehaviour
// {
//     [SerializeField] private GateData _gateData; // 门数据

//     private void OnTriggerEnter(Collider other)
//     {
//         if (!other.CompareTag("Player"))
//         {
//             return;
//         }

//         Player player = other.GetComponent<Player>();
//         if (player == null)
//         {
//             return;
//         }

//         switch (_gateData.EffectType)
//         {
//             case GateEffectType.ClonePlayer:
//                 player.AddClone(_gateData.CloneNumber);
//                 break;
//             case GateEffectType.ChangWeapon:
//                 player.WeaponToEquip(_gateData.WeaponToEquip);
//                 break;
//         }

//     }

    



//     public enum GateEffectType
//     {
//         ClonePlayer,
//         ChangWeapon
//     }

//     [CreateAssetMenu(fileName = "GateData", menuName = "GateData")]

//     public class GateData : ScriptableObject 
//     {
//         public GateEffectType EffectType; // 门效果类型
//         public WeaponData WeaponToEquip; // 武器数据
//         public int CloneNumber; // 克隆数量
//     }


//     // [Tooltip("门变化数量：+2生成2人，‑2删除2人")]
//     // public int NumberOfPlayers;
// }

