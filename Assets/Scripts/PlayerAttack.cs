using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public event Action Hit;
    
    private void OnMouseDown()
    {
        Hit?.Invoke();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Hit?.Invoke();
    }
}
