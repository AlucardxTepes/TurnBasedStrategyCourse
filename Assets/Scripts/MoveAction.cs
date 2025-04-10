using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int maxMoveDistance = 4;

    private Vector3 targetPosition;
    private Unit unit;

    void Awake()
    {
        unit = GetComponent<Unit>();
        // Initialize target position to the unit's current position, this prevents the unit from moving to 0,0 at the start
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float stopDistance = 0.1f; // Distance to stop moving towards the target position
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            unitAnimator.SetBool("isWalking", true);
            Vector3 moveDirection = (targetPosition - transform.position).normalized; // Calculate the direction to the target position
            float rotateSpeed = 15f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed); // Rotate the unit to face the target position
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            unitAnimator.SetBool("isWalking", false);
        }

    }

    public void MoveTo(Vector3 newPosition)
    {
        targetPosition = newPosition;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPosition.x, 0, newPosition.z), moveSpeed * Time.deltaTime);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();

        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;
                Debug.Log(testGridPosition);
            }
        }

        return validGridPositionList;
    }
}
