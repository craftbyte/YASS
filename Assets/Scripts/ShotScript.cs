using UnityEngine;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
  public int damage = 1;

  public bool isEnemyShot = false;

  void Start()
  {
    Destroy(gameObject, 20); // 20sec
  }
}