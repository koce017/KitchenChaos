using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float playerRadius = 0.7f;
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var moveDir = GetMovementDirection();
        isWalking = moveDir != Vector3.zero;
        transform.position += moveSpeed * Time.deltaTime * moveDir;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }

    private Vector3 GetMovementDirection()
    {
        var inputVector = gameInput.GetMovementVector();
        var moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;
        if (!IsCollidingWithObstacle(moveDir, moveSpeed * Time.deltaTime))
            return moveDir;

        // if we can't move in the desired direction, try moving along the individual axes
        var moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
        if (!IsCollidingWithObstacle(moveDirX, moveSpeed * Time.deltaTime)) // try moving only in the X direction
            return moveDirX;

        var moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
        if (!IsCollidingWithObstacle(moveDirZ, moveSpeed * Time.deltaTime))
            return moveDirZ;

        return Vector3.zero;
    }

    private bool IsCollidingWithObstacle(Vector3 direction, float maxDistance)
    {
        return Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, direction, maxDistance);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
