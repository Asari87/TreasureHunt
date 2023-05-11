using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildModelPicker : MonoBehaviour
{
    [SerializeField] private bool allowMultiple = false;
    private void Awake()
    {
        if (transform.childCount == 0)
        {
            Debug.LogError($"{name} deos not contain house models!", this);
        }

    }

    private void TurnOffModels()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }

    [ContextMenu("Randomize Building")]
    private void ActivateRandomBuilding()
    {
        TurnOffModels();
        for (int i = 0; i < transform.childCount; i++)
        {
            bool enable = Random.Range(0f, 1f) > .5f;
            transform.GetChild(i).gameObject.SetActive(enable);
            if (enable && !allowMultiple)
                return;
        }
    }
}
