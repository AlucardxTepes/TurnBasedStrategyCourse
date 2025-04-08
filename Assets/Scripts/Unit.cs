using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;

    private void Update()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized; // Calculate the direction to the target position
        float moveSpeed = 4f;
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f) { // Check if the unit is close to the target position
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4, 0, 4));
        }
    }



    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;        // Move the unit to the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);
    
    }

}
