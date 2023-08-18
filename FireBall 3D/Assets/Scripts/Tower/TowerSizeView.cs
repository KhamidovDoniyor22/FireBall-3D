using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private Text _sizeView;
    [SerializeField] private Tower _tower;
    private void OnEnable()
    {
        _tower.SizeUpdate += OnSizeUpdate;
    }
    private void OnDisable()
    {
        _tower.SizeUpdate -= OnSizeUpdate;
    }
    private void OnSizeUpdate(int size)
    {
        _sizeView.text = size.ToString();
    }
}
