using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;  //HUD 터렛 이미지랑 맵이 겹쳤을 때, 클릭 시 터렛 이미지만 선택되고 땅은 선택 안되게끔

        //if (buildManager.GetTurretToBuild() == null) return;
        if (!buildManager.CanBuild) return;

        if (turret != null)
        {
            Debug.Log("Can't build there!!!");
            return;
        }

        buildManager.BuildTurretOn(this);

       // GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
       // turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        //if (buildManager.GetTurretToBuild() == null) return;
        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else 
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
