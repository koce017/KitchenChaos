using System;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public void Interact()
    {
        Transform kitchenObjecte = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjecte.localPosition = Vector3.zero; // set the local position to zero to place it at the counter top point
    }
}
