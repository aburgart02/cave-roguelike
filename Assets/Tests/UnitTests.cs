using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class UnitTests
{
    public static GameObject CreateGameObjectWithCollider(bool isTrigger)
    {
        var obj = new GameObject();
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        obj.AddComponent<BoxCollider2D>();
        obj.GetComponent<BoxCollider2D>().isTrigger = isTrigger;
        return obj;
    }

    public static void PutObjectsAtTheSamePosition(GameObject first, GameObject second)
    {
        first.transform.position = new Vector2(0, 0);
        second.transform.position = new Vector2(0, 0);
    }

    [UnityTest]
    public IEnumerator HealthTakeDamage()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.TakeDamage(20);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(health.maxHealth - 20, health.health);
    }

    [UnityTest]
    public IEnumerator HealthWhenNotPlayerHasZeroHealth()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.TakeDamage(health.maxHealth);
        yield return new WaitForSeconds(0.25f);
        Assert.That(gameObject == null);
    }


    [UnityTest]
    public IEnumerator HealthWhenPlayerHasZeroHealth()
    {
        var gameObject = new GameObject();
        gameObject.tag = "Player";
        var health = gameObject.AddComponent<Health>();
        health.TakeDamage(health.maxHealth);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator HealthThereIsAnimationAfterDeath()
    {
        var obj = new GameObject();
        obj.AddComponent<Health>();
        var health = obj.GetComponent<Health>();
        health.DeathAnimation = new GameObject();
        health.DeathAnimation.tag = "Test";
        var testObjectCountBeforeTakingDamage = GameObject.FindGameObjectsWithTag("Test").Length;
        health.TakeDamage(health.maxHealth);
        var testObjectCountAfterTakingDamage = GameObject.FindGameObjectsWithTag("Test").Length;
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(1, testObjectCountAfterTakingDamage - testObjectCountBeforeTakingDamage);
    }

    [UnityTest]
    public IEnumerator HealPlayerWhenHealthIsLessThanMaxHealth()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.health = 50;
        health.HealPlayer(20);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(70, health.health);
    }

    [UnityTest]
    public IEnumerator HealPlayerWhenHealthIsGreaterThanMaxHealth()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.HealPlayer(20);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(health.maxHealth, health.health);
    }

    [UnityTest]
    public IEnumerator MainMenuLoadGame()
    {
        SceneManager.LoadScene(0);
        var gameObject = new GameObject();
        var menu = gameObject.AddComponent<Mainmenu>();
        menu.PlayGame();
        yield return new WaitForSeconds(0.25f);
        Assert.That(SceneManager.GetActiveScene().name != "Menu");
    }

    [UnityTest]
    public IEnumerator FireShootBulletCreationIsLimitedByMaxBullet()
    {
        var gameObject = new GameObject();
        var fire = gameObject.AddComponent<Fire>();
        fire.bullet = new GameObject();
        fire.Fireposition = (new GameObject()).transform;
        for (var i = 0; i < fire.maxBullets + 2; i++)
            fire.Shoot();
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(fire.maxBullets, fire.bullets.Count);
    }

    [UnityTest]
    public IEnumerator FireBulletSpawnAtFirePosition()
    {
        var gameObject = new GameObject();
        var fire = gameObject.AddComponent<Fire>();
        fire.bullet = new GameObject();
        fire.Fireposition = (new GameObject()).transform;
        fire.Fireposition.position = new Vector2(1, 1);
        fire.Shoot();
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(fire.Fireposition.position, fire.bullets[0].transform.position);
    }

    [UnityTest]
    public IEnumerator SpawnNewObjectAfterDrop()
    {
        var gameObject = new GameObject();
        var spawn = gameObject.AddComponent<Spawn>();
        spawn.item = new GameObject();
        spawn.spawnPosition = (new GameObject()).transform;
        spawn.spawnPosition.position = new Vector2(1, 1);
        spawn.item.tag = "Test";
        var testObjectsCountBeforeSpawnDroppedItem = GameObject.FindGameObjectsWithTag("Test").Length;
        spawn.SpawnDroppedItem();
        var testObjectsCountAfterSpawnDroppedItem = GameObject.FindGameObjectsWithTag("Test").Length;
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(1, testObjectsCountAfterSpawnDroppedItem - testObjectsCountBeforeSpawnDroppedItem);
    }

    [UnityTest]
    public IEnumerator PeriodShootSpawnObjectAfterShoot()
    {
        var gameObject = new GameObject();
        var periodShoot = gameObject.AddComponent<PeriodShoot>();
        periodShoot.bullet = new GameObject();
        periodShoot.firePoint = (new GameObject()).transform;
        periodShoot.bullet.tag = "Test";
        var testObjectsCountBeforeSpawnDroppedItem = GameObject.FindGameObjectsWithTag("Test").Length;
        periodShoot.Shoot();
        var testObjectsCountAfterSpawnDroppedItem = GameObject.FindGameObjectsWithTag("Test").Length;
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(1, testObjectsCountAfterSpawnDroppedItem - testObjectsCountBeforeSpawnDroppedItem);
    }

    [UnityTest]
    public IEnumerator FlyObjectDieWhenTrigger()
    {
        var bullet = CreateGameObjectWithCollider(true);
        bullet.AddComponent<Fly>();
        var objForCollision = CreateGameObjectWithCollider(false);
        PutObjectsAtTheSamePosition(bullet, objForCollision);
        yield return new WaitForSeconds(0.25f);
        Assert.That(bullet == null);
    }

    [UnityTest]
    public IEnumerator FlyDamageWhenTrigger()
    {
        var bullet = CreateGameObjectWithCollider(true);
        bullet.AddComponent<Fly>();
        var damage = bullet.GetComponent<Fly>().damage;
        var objForCollision = CreateGameObjectWithCollider(false);
        objForCollision.AddComponent<Health>();
        PutObjectsAtTheSamePosition(bullet, objForCollision);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(objForCollision.GetComponent<Health>().maxHealth - damage,
            objForCollision.GetComponent<Health>().health);
    }

    [UnityTest]
    public IEnumerator HealIncreaseHealthWhenTrigger()
    {
        var bottle = CreateGameObjectWithCollider(true);
        bottle.AddComponent<Heal>();
        bottle.transform.position = new Vector2(324, 0);
        var objForCollision = CreateGameObjectWithCollider(false);
        objForCollision.tag = "Player";
        objForCollision.AddComponent<Health>();
        var health = objForCollision.GetComponent<Health>();
        health.health = health.maxHealth / 2;
        bottle.GetComponent<Heal>().increasedHealth = health.health;
        PutObjectsAtTheSamePosition(bottle, objForCollision);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(health.maxHealth, health.health);
    }

    [UnityTest]
    public IEnumerator HealDestroyAfterTrigger()
    {
        var bottle = CreateGameObjectWithCollider(true);
        bottle.AddComponent<Heal>();
        var objForCollision = CreateGameObjectWithCollider(false);
        objForCollision.tag = "Player";
        objForCollision.AddComponent<Health>();
        PutObjectsAtTheSamePosition(bottle, objForCollision);
        yield return new WaitForSeconds(0.25f);
        Assert.That(bottle == null);
    }

    [UnityTest]
    public IEnumerator KeyDetectionDoorOpeningWhenTriggersWithRightKey()
    {
        var door = CreateGameObjectWithCollider(true);
        door.AddComponent<KeyDetection>();
        door.GetComponent<KeyDetection>().keyTag = "RedKey";
        var key = CreateGameObjectWithCollider(true);
        key.tag = "RedKey";
        PutObjectsAtTheSamePosition(door, key);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(true, door.GetComponent<KeyDetection>().opening);
    }

    [UnityTest]
    public IEnumerator KeyDetectionDoorNotOpeningWhenTriggersWithWrongKey()
    {
        var door = CreateGameObjectWithCollider(true);
        door.AddComponent<KeyDetection>();
        door.GetComponent<KeyDetection>().keyTag = "RedKey";
        var key = CreateGameObjectWithCollider(true);
        key.tag = "BlueKey";
        PutObjectsAtTheSamePosition(door, key);
        yield return new WaitForSeconds(0.25f);
        Assert.AreEqual(false, door.GetComponent<KeyDetection>().opening);
    }

    [UnityTest]
    public IEnumerator KeyDetectionRightKeyIsDestroyedAfterTriggerWithDoor()
    {
        var door = CreateGameObjectWithCollider(true);
        door.AddComponent<KeyDetection>();
        door.GetComponent<KeyDetection>().keyTag = "RedKey";
        var key = CreateGameObjectWithCollider(true);
        key.tag = "RedKey";
        PutObjectsAtTheSamePosition(door, key);
        yield return new WaitForSeconds(0.25f);
        Assert.That(key == null);
    }

    [UnityTest]
    public IEnumerator KeyDetectionWrongKeyIsNotDestroyedAfterTriggerWithDoor()
    {
        var door = CreateGameObjectWithCollider(true);
        door.AddComponent<KeyDetection>();
        door.GetComponent<KeyDetection>().keyTag = "RedKey";
        var key = CreateGameObjectWithCollider(true);
        key.tag = "BlueKey";
        PutObjectsAtTheSamePosition(door, key);
        yield return new WaitForSeconds(0.25f);
        Assert.That(key != null);
    }
}
