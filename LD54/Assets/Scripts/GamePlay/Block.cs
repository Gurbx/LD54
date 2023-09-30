using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay
{
    public class Block : MonoBehaviour
    {
        public Mob Mob { get; private set; }
        public  BlockData Data { get; private set; }
        
        private void Awake()
        {
            transform.DOMoveY(-0.1f, 2f).SetDelay(Random.Range(0, 2f)).SetEase(Ease.InOutSine).SetRelative(true)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void Initialize(BlockData blockData, Vector3 position)
        {
            Data = blockData;
            transform.position = position;
        }
        
        public void SetMob(Mob mob)
        {
            Mob = mob;
            mob.transform.parent = transform;
        }
        
    }
}
