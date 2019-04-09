using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryScript {
    [SerializeField]
    public Augment[] augmentations;

    public Augment[] G_augmentations
    {
        get { return augmentations; }
    }

    public InventoryScript()
    {
        augmentations = new Augment[System.Enum.GetNames(typeof(Aug_Placement)).Length - 1];
    }


    public void SetNewAugPlacement(Augment newAugment, bool exchange)
    {
        if (augmentations == null)
        {
            augmentations = new Augment[System.Enum.GetNames(typeof(Aug_Placement)).Length - 1];
        }
        if (augmentations[(int)newAugment.GS_placement] == null && !exchange)
        {
            augmentations[(int)newAugment.GS_placement] = newAugment;
        }
        if (augmentations[(int)newAugment.GS_placement].GS_name != null && exchange)
        {
            RemoveAugment(newAugment.GS_placement);
            augmentations[(int)newAugment.GS_placement] = newAugment;
        }
    }
    public void RemoveAugment(Aug_Placement removalPlacement)
    {
        //inventory.Add(augmentations[(int)removalPlacement]);
        augmentations[(int)removalPlacement] = null;
    }
}
