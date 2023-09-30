using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BlockData")]
    public class BlockData : ScriptableObject
    {
        public Material material;
        public Element element;
    }
}