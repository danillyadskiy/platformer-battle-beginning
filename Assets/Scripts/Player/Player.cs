using System;
using UnityEngine;

public class Player : Character
{
    private readonly int _maxHealth = 100;
    
    public void RestoreHealth()
    {
        Health = _maxHealth;
    }
    
    private void Start()
    {
        Health = _maxHealth;
    }
}
