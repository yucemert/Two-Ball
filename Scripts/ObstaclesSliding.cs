using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstaclesSliding : MonoBehaviour
{
   
   [SerializeField] float slideDistance;
   [SerializeField] float slideDuration;
    void Start()
    {
        transform
        .DOLocalMoveX(slideDistance,slideDuration)
        .SetLoops(-1,LoopType.Yoyo)
        .SetEase(Ease.InOutBack);
        
    }

   
}
