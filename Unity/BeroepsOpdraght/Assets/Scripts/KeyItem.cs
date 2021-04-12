using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (VariableCounts.KeyCount > 2 && other.gameObject.name == "Player")
        {
            VariableCounts.KeyCount -= 2;
            Destroy(gameObject);
        }

        if (VariableCounts.KeyCount < 2 && other.gameObject.name == "Player")
        {
            VariableCounts.KeyCount -= 1;
            Destroy(gameObject);
        }
    }
}
