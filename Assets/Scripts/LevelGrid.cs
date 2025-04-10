using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set;}

    [SerializeField] private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;

    private void Awake()
    {
        // singleton
        if (Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid instance" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        } else {
            Instance = this;
        }
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void AddUnitToGridPosition(GridPosition gridPosition, Unit unit) => gridSystem.GetGridObject(gridPosition).AddUnit(unit);
    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition) => gridSystem.GetGridObject(gridPosition).GetUnitList();
    public void RemoveUnitFromGridPosition(GridPosition gridPosition, Unit unit) => gridSystem.GetGridObject(gridPosition).RemoveUnit(unit);
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    
    public void UnitMovedGridPosition(Unit unit, GridPosition from, GridPosition to)
    {
        RemoveUnitFromGridPosition(from, unit);
        AddUnitToGridPosition(to, unit);
    }

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);
    public bool HasAnyUnitOnGridPosition(GridPosition gridPosition) => gridSystem.GetGridObject(gridPosition).HasAnyUnit();
    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
    public int GetWidth() => gridSystem.GetWidth();
    public int GetHeight() => gridSystem.GetHeight();


}
