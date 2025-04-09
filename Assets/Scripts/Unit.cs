using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;

    private void Awake()
    {
        // Initialize target position to the unit's current position, this prevents the unit from moving to 0,0 at the start
        targetPosition = transform.position;
    }

    private void Update()
    {
        float stopDistance = 0.1f; // Distance to stop moving towards the target position

        // Check if the unit is close to the target position
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        { 
            unitAnimator.SetBool("isWalking", true);
            Vector3 moveDirection = (targetPosition - transform.position).normalized; // Calculate the direction to the target position
            float moveSpeed = 4f;
            float rotateSpeed = 15f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed); // Rotate the unit to face the target position
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        } else 
        {
            unitAnimator.SetBool("isWalking", false);
        }
    }



    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;        // Move the unit to the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);

    }

}
