using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace Main
{
    [Serializable]
    public struct Range
    {
        public Range(float min, float max)
        {
            Min = min;
            Max = max;
        }
        [field: SerializeField] public float Min { get; private set; }
        [field: SerializeField] public float Max { get; private set; }
    }

    //ブロックを等間隔に配置する
    public class BlockInit : MonoBehaviour
    {
        //[SerializeField] 

        void Awake()
        {
            for (float x = RangeX.Min; x < RangeX.Max; x += Density.x)
            {
                for (float y = RangeY.Min; y < RangeY.Max; y+= Density.y)
                {
                    GameObject block = Instantiate(_targetPrefab, _parent.transform);
                    block.transform.position = new Vector3((2f + (1f * y)), 0.4f, (-4.2f + (1.2f * x)));
                }
            }
        }

        [SerializeField] private GameObject _targetPrefab;
        [SerializeField] private GameObject _parent;

        [field: SerializeField] public  Range RangeX { get; set; } = new(0, 5);
        [field: SerializeField] public Range RangeY { get; set; } = new(0, 5);
        [field: SerializeField] public Vector2 Density { get; set; } = new(0.5f, 1);
    }
}