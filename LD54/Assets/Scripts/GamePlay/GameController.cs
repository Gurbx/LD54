using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class GameController : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Transform cameraTarget;
        
        [Header("Assets")]
        [SerializeField] private BlockData blockData;
        
        [SerializeField] private Block blockPrefab; // TODO Different block  & Mob types
        [SerializeField] private Mob mobPrefab;

        [SerializeField] private Transform blockContainer;

        private List<Block> _blocks;

        private void Awake()
        {
            foreach (Transform child in blockContainer)
                Destroy(child.gameObject);

            _blocks = new List<Block>();
            
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    var block = Instantiate(blockPrefab, blockContainer);
                    block.Initialize(blockData, new Vector3(x, 0, y));
                    _blocks.Add(block);
                }
            }

            UpdateCameraTargetPosition();
        }

        private void UpdateCameraTargetPosition()
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            foreach (var block in _blocks)
            {
                if (block.transform.position.x < minX)
                    minX = block.transform.position.x;
                if (block.transform.position.z < minY)
                    minY = block.transform.position.z;
                if (block.transform.position.x > maxX)
                    maxX = block.transform.position.x;
                if (block.transform.position.z > maxY)
                    maxY = block.transform.position.z;
            }

            cameraTarget.transform.position = new Vector3((maxX - minX)/2f, 0,(maxY - minY)/2);
        }


        public void NextTurn()
        {
            
        }
    }
}
