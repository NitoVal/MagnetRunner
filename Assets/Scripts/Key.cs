using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        Red,
        Blue,
        Green,
        Yellow
    }
    public KeyType GetKeyType() { return keyType; }
}
