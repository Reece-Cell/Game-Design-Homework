using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;

    public Color notEnoughMoneyColor;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    BuildManager buildManager;
    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if(turret != null){
            buildManager.SelectNode(this); 
            return;
        }
        if (!buildManager.CanBuild){
            return;
        }
        //Build a turret
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost){
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
}  

public void UpgradeTurret()
{
        if(PlayerStats.Money < turretBlueprint.upgradeCost){
            Debug.Log("Not enough money to upgrade that!");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        //Make new upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        
}

    public void SellTurret ()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;
	}

    void OnMouseEnter() {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if (!buildManager.CanBuild)
            return;
        if(buildManager.HasMoney){
            rend.material.color= hoverColor;
        }else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
