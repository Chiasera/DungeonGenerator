using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New dungeon", menuName = "Dungeon asset")]
public class DungeonData : ScriptableObject
{
    [SerializeField]
    private ScriptableObject activeLayout;
    private GameObject mono; //The monobehaviour using that data, i.e. the dungeon
    [SerializeField]
    RandomWalk randomWalkParameters; //already initialized in inspector
    [SerializeField]
    StandardCorridor corridorsParameters;  //already initialized in inspector
    private DungeonWallGenerator walls = new DungeonWallGenerator();

    public void GenerateDungeon()
    {       
        ClearDungeon();
        randomWalkParameters.ExecuteRandomWalk();
        corridorsParameters.GenerateCorridors(randomWalkParameters);
        walls.CreateWalls(corridorsParameters.GetCorridorsLayout());
        DungeonDrawer.Draw(corridorsParameters.GetPositionsBuffer(), mono, PrimitiveType.Cube);
        DungeonDrawer.Draw(walls.GetPositionsBuffer(), mono, PrimitiveType.Sphere);
    }

    public void ClearDungeon() 
    {
        if (randomWalkParameters.GetMonoInstance() == null) 
            randomWalkParameters.SetMonoInstance(mono);
        if (walls.GetMonoInstance() == null)
            walls.SetMonoInstance(mono);
        if (corridorsParameters.GetMonoInstance() == null)
            corridorsParameters.SetMonoInstance(mono);

        randomWalkParameters.ClearBuffer();
        corridorsParameters.ClearBuffer();
        walls.ClearBuffer();
        DungeonDrawer.EraseDungeon(mono);
    }

    public DungeonWallGenerator GetWallsData() 
    {
        return walls; 
    }

    public void SaveData()
    {
        GetActiveLayout().SaveFloorData(randomWalkParameters.GetPositionsBuffer());
        GetActiveLayout().SaveWallsData(walls.GetPositionsBuffer()); //expected not to be null   
    }

    public void LoadData()
    {
        ClearDungeon();
        DungeonDrawer.Draw(GetActiveLayout().GetFloorData(), mono, PrimitiveType.Cube);
        DungeonDrawer.Draw(GetActiveLayout().GetWallsData(), mono, PrimitiveType.Sphere);
    }

    public void SetMonoInstance(GameObject mono)
    {
        this.mono = mono;
    }

    public DungeonLayout GetActiveLayout()
    {
        return activeLayout as DungeonLayout;
    }
}
