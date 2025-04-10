using UnityEngine;

public class Unit : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GridPosition gridPosition;
    private MoveAction moveAction;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitToGridPosition(gridPosition, this);
    }

    private void Update()
    {        
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != gridPosition)
        {
            // unit changed Grid Position
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction() => this.moveAction;

    public override string ToString()
    {
        return this.name;
    }

    public GridPosition GetGridPosition() => this.gridPosition;

}
