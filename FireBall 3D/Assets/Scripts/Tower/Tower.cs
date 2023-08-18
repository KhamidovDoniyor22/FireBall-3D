using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdate;
    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach(var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }
    private void OnBulletHit(Block heatedBlock)
    {
        heatedBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(heatedBlock);

        foreach(var block in _blocks)
        {
            block.transform.position = new Vector3(
                block.transform.position.x, 
                block.transform.position.y - block.transform.localScale.y, 
                block.transform.position.x);
        }

        SizeUpdate?.Invoke(_blocks.Count);
    }
}
