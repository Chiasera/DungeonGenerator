using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    private DungeonData dungeonData;

    private void Awake()
    {
        dungeonData.SetMonoInstance(this.gameObject);
    }

    private void Update()
    {
        
    }
}
