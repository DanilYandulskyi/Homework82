using UnityEngine;
using System;

public class Flag : MonoBehaviour, IUnitTarget
{
    public event Action OnDisable;

    public Transform Transform => transform;

    public void Disable()
    {
        OnDisable?.Invoke();
        gameObject.SetActive(false);
    }
}
