using System;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public event Action AmountChanged;
    
    public int Coins { get; private set; }
    
    public void AddCoin()
    {
        Coins++;
        AmountChanged?.Invoke();
    }
}
