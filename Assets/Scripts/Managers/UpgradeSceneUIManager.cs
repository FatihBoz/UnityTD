using TMPro;
using UnityEngine;

public class UpgradeSceneUIManager : MonoBehaviour
{
    [Header("Tower Level Texts")]
    [SerializeField] private TextMeshProUGUI arrowTowerText;
    [SerializeField] private TextMeshProUGUI slingshotTowerText;
    [SerializeField] private TextMeshProUGUI shockTowerText;
    [SerializeField] private TextMeshProUGUI cursedTowerText;

    [Header("Skill Level Texts")]
    [SerializeField] private TextMeshProUGUI fireBomb;
    [SerializeField] private TextMeshProUGUI lightning;


    private void Start()
    {
        RefreshTowerLevelInfo();
        RefreshSkillLevelInfo();
    }

    public void RefreshTowerLevelInfo()
    {
        arrowTowerText.text = "LV. " + UpgradeSceneManager.towerLevels["ArrowTower"].ToString();
        slingshotTowerText.text = "LV. " + UpgradeSceneManager.towerLevels["SlingshotTower"].ToString();
        shockTowerText.text = "LV. " + UpgradeSceneManager.towerLevels["ShockTower"].ToString();
        cursedTowerText.text = "LV. " + UpgradeSceneManager.towerLevels["CursedTower"].ToString();
    }


    public void RefreshSkillLevelInfo()
    {
        fireBomb.text = "LV. " + UpgradeSceneManager.skillLevels["FireBomb"].ToString();
        lightning.text = "LV. " + UpgradeSceneManager.skillLevels["Lightning"].ToString();
    }
}
