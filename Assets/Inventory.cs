using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public int activeSlot = 0;
    private Color semitransparent = new Color(1f, 1f, 1f, 0.5f);
    private Color solid = new Color(1f, 1f, 1f);

    private void SetActiveSlot(int index)
    {
        activeSlot = index;
        for (var i = 0; i < 3; i++)
            if (i == index) slots[i].GetComponent<SpriteRenderer>().color = solid;
            else slots[i].GetComponent<SpriteRenderer>().color = semitransparent;
    }

    private void Start()
    {
        SetActiveSlot(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveSlot(0);
            Debug.Log(activeSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveSlot(1);
            Debug.Log(activeSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveSlot(2);
            Debug.Log(activeSlot);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            slots[activeSlot].GetComponent<Slot>().DropItem();
        }
    }
}
