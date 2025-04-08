using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;

    private void Update()
    {
        float stopDistance = 0.1f; // Distance to stop moving towards the target position
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        { // Check if the unit is close to the target position
            Vector3 moveDirection = (targetPosition - transform.position).normalized; // Calculate the direction to the target position
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }
    }



    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;        // Move the unit to the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);

    }

}
