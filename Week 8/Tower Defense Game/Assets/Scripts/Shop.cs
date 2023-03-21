using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;
    private void Start() {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurrelToBuild(standardTurret);
    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurrelToBuild(missileLauncher);
    }
        public void PurchaseLaserBeamer()
    {
        Debug.Log("laser Beamer Selected");
        buildManager.SelectTurrelToBuild(laserBeamer);
    }
}
