using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Dead;

    private bool _isAlive = true;
    
    public void GetDamage()
    {
        if (_isAlive)
        {
            _isAlive = false;
            Dead?.Invoke();
        }
    }
}
