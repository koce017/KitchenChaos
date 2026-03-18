using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        var inputVector = gameInput.GetMovementVectorNormalized();
        var moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        isWalking = moveDir != Vector3.zero;

        transform.position += moveSpeed * Time.deltaTime * moveDir;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
