using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DungeonFeature 
{
    protected List<Vector3> positionsBuffer = new List<Vector3>();
    protected GameObject mono;

    public List<Vector3> GetPositionsBuffer()
    {
        return positionsBuffer;
    }

    public void SetMonoInstance(GameObject mono)
    {
        this.mono = mono;
    }

    public GameObject GetMonoInstance()
    {
        return mono;
    }

    public void ClearBuffer()
    {
        positionsBuffer = new List<Vector3>();
    }
}
