using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradePanel
{
    void UpgradePanel();

    void Upgrade();

    void SetUpgradeCosts();

    void RefreshInformation();

    bool ConditionsAreSatisfied();
}
