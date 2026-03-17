using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;

    private bool isWalking;

    private void Update()
    {
        var inputVector = new Vector2();

        if (Keyboard.current.wKey.isPressed)
            inputVector.y = +1;

        if (Keyboard.current.sKey.isPressed)
            inputVector.y = -1;

        if (Keyboard.current.aKey.isPressed)
            inputVector.x = -1;

        if (Keyboard.current.dKey.isPressed)
            inputVector.x = +1;

        inputVector.Normalize();
        
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
