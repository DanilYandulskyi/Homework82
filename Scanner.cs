using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Scanner : MonoBehaviour
{
    [SerializeField] private List<Gold> _goldList = new List<Gold>();
    [SerializeField] private float _scanDelay;
    [SerializeField] private float _scanRadius;

    public IReadOnlyList<Gold> GoldList => _goldList;

    private void Start()
    {
        StartCoroutine(Scan());
    }

    public void RemoveGold(Gold gold)
    {
        if (_goldList.Contains(gold))
        {
            _goldList.Remove(gold);
        }
    }
    
    private IEnumerator Scan()
    {
        WaitForSeconds waiter = new WaitForSeconds(_scanDelay);

        while (enabled)
        {
            yield return waiter;

            Collider[] colliders = Physics.OverlapSphere(transform.position, _scanRadius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Gold gold))
                {
                    if (_goldList.Contains(gold) == false)
                    {
                        _goldList.Add(gold);
                    }
                }
            }
        }
    }
}
