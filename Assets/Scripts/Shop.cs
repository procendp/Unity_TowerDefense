using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint upgradeTurret;
    
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }


    // public void PurchaseStandardTurret()
    // {
    //     Debug.Log("Standard Turret purchased");
    //     buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    // }

    // public void PurchaseUpgradeTurret()
    // {
    //     Debug.Log("Upgrade Turret purchased");
    //     buildManager.SetTurretToBuild(buildManager.upgradeTurretPrefab);
    // }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectUpgradeTurret()
    {
        Debug.Log("Upgrade Turret Selected");
        buildManager.SelectTurretToBuild(upgradeTurret);
    }
}
