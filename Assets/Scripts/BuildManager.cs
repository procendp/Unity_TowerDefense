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
    
    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
}
