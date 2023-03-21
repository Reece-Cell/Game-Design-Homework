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
    [Header("Optional")]
    public GameObject turret;

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
        if (!buildManager.CanBuild){
            return;
        }
        if(turret != null){
            Debug.Log("Can't build here");
            return;
        }
        //Build a turret
        buildManager.BuildTurretOn(this);
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
