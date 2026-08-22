using UnityEngine; // 引用组件
using NUnit.Framework;
using System.Collections.Generic;

public class SpawnGroup : MonoBehaviour
{
    [SerializeField] private GameObject _prefabPlayer; 

    private int _maxPerRow = 3; // 最大玩家数量3
    private float _XSpasing = 2f;
    private float _ZSpacing = 2f;
    private List<GameObject> _allPlayers = new List<GameObject>(); 

    private void Start()
    {
        _allPlayers.Add(gameObject);
        UpdatePosition();
    }

    public void CreateNewPlayer()
    {
        GameObject newPlayer = Instantiate(_prefabPlayer, transform.position, Quaternion.identity);
        _allPlayers.Add(newPlayer);
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        for(int i = 0; i < _allPlayers.Count; i++)
        {
            int row = i / _maxPerRow;
            int col = i % _maxPerRow;

            float xOffset = col * _XSpasing;

            Vector3 newPos = transform.position + new Vector3(xOffset, transform.position.y, -row * _ZSpacing);

            _allPlayers[i].transform.position = newPos;
        }

    }
}
