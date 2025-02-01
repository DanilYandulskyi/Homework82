using UnityEngine;
using System.Collections.Generic;

public class FreeGoldFinder : MonoBehaviour
{
    [SerializeField] private Scanner _scanner;
    
    private List<Gold> _takenGoldList;

    public Gold GetFreeGold()
    {
        foreach (var gold in _scanner.GoldList)
        {
            if (_takenGoldList.Contains(gold) == false)
            {
                _takenGoldList.Add(gold);
                _scanner.RemoveGold(gold);
            }

            return gold;
        }

        return null;
    }
}
