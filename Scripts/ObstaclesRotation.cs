using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstaclesRotation : MonoBehaviour
{
    [SerializeField] float rotationDuration;

        void Start()
    {
        transform
        .DORotate(new Vector3(0f,0f,1f),rotationDuration)
        .SetLoops(-1,LoopType.Incremental);
    }

   
}
