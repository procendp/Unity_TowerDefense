using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //singleton

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject upgradeTurretPrefab;

    private TurretBluePrint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null;} }
    public bool HasMoney { get { return GameStats.Money >= turretToBuild.cost;} }

    public void BuildTurretOn (Node node)
    {
        if (GameStats.Money < turretToBuild.cost)
        {
            Debug.Log ("Show me the Money!!!");
            return;
        }

        GameStats.Money -= turretToBuild.cost;  //터렛 지을 때마다 감액

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money Left : " + GameStats.Money);
    }
    
    // void Start()
    // {
    //     turretToBuild = standardTurretPrefab;
    // }

    // public GameObject GetTurretToBuild ()
    // {
    //     return turretToBuild;
    // }

    // public void SetTurretToBuild(GameObject turret)
    // {
    //     turretToBuild = turret;
    // }

    public void SelectTurretToBuild (TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
