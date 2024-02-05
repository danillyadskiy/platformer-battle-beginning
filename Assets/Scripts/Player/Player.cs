using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Dead;

    public bool IsAlive { get; private set; }

    private void Start()
    {
        IsAlive = true;
    }

    public void GetDamage()
    {
        if (IsAlive)
        {
            IsAlive = false;
            Dead?.Invoke();
        }
    }
}
