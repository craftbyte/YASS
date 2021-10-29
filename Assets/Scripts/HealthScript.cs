using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
  public GameObject DroppedPickup;
  /// <summary>
  /// Total hitpoints
  /// </summary>
  public int hp = 1;

  /// <summary>
  /// Enemy or player?
  /// </summary>
  public bool isEnemy = true;

  private int startHp;

  void Start() {
    startHp = hp;
  }

  /// <summary>
  /// Inflicts damage and check if the object should be destroyed
  /// </summary>
  /// <param name="damageCount"></param>
  public void Damage(int damageCount, bool points)
  {
    hp -= damageCount;

    if (hp <= 0)
    {
      if(isEnemy && points) {
        ScoreHelper.Instance.AddScore(startHp*500);
        SoundEffectsHelper.Instance.MakeExplosionSound();
        if (Random.value > 0.9f) {
            var pickup = Instantiate(DroppedPickup);
            pickup.transform.position = transform.position;
            pickup.transform.parent = transform.parent;
        }
      }
      Destroy(gameObject);
      if (!isEnemy) SceneManager.LoadScene("GameOverScene");
    }
  }

  void OnTriggerEnter2D(Collider2D otherCollider)
  {
    // Is this a shot?
    ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
    if (shot != null)
    {
      // Avoid friendly fire
      if (shot.isEnemyShot != isEnemy)
      {
        Damage(shot.damage, true);

        // Destroy the shot
        Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
      }
    }
  }
}