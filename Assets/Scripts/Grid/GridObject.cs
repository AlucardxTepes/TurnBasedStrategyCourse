using System;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }

    public override string ToString()
    {
        // Debug.Log("Unit in pos " + gridPosition.x + ", " + gridPosition.z + ": " + unit);
        string unitString = "";
        foreach (Unit u in unitList)
        {
            unitString += u + "\n";
        }
        return $"{gridPosition.ToString()} \n {unitString}";
    }

    public void ClearPosition()
    {
        unitList = null;
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }
}
