using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] Starship player;
    [SerializeField] Starship opponent;
    [SerializeField] Text playerHealth;
    [SerializeField] Text playerPoints;
    [SerializeField] Text opponentHealth;
    [SerializeField] Text actionResult;
    [SerializeField] Image playerLaser;
    [SerializeField] Image[] opponentExplosions;

    public void playerShoot() { StartCoroutine(shoot(player, opponent)); }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.text = player.getHealth().ToString();
        playerPoints.text = player.getActionPoints().ToString();
        opponentHealth.text = opponent.getHealth().ToString();
        //actionResult.text = "";
        actionResult.gameObject.SetActive(false);
        playerLaser.gameObject.SetActive(false);
        opponentExplosions[0].gameObject.SetActive(false);
        opponentExplosions[1].gameObject.SetActive(false);
        opponentExplosions[2].gameObject.SetActive(false);
    }

    public void updateScene() {
        playerHealth.text = player.getHealth().ToString();
        playerPoints.text = player.getActionPoints().ToString();
        opponentHealth.text = opponent.getHealth().ToString();
    }

    public IEnumerator shoot(Starship shooter, Starship target) {
        yield return activatePlayerLaser();
        int result = shooter.hit(target);
        yield return new WaitForSeconds(0.5f);
        yield return activateOpponentExplosions();
        actionResult.text = "HIT! " + result.ToString() + " Damage!";
        actionResult.gameObject.SetActive(true);
        updateScene();
        yield return new WaitForSeconds(3);
    }
    public IEnumerator activateOpponentExplosions() {
        for(int i = 0; i < 3; i++) {
            opponentExplosions[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            opponentExplosions[i].gameObject.SetActive(false);
        }
    }

    public IEnumerator activatePlayerLaser() {
        for (int i = 0; i < 4; i++) {
            playerLaser.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            playerLaser.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);
        }
    }
    // Update is called once per frame
    void Update()
    {
           
    }
}
