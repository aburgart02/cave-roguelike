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

    [UnityTest]
    public IEnumerator HealthTakeDamage()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.TakeDamage(20);
        yield return null;
        Assert.AreEqual(80, health.health);
    }

    [UnityTest]
    public IEnumerator HealthIsZeroNotPlayer()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.TakeDamage(100);
        yield return null;
        Assert.That(gameObject == null);
    }


    [UnityTest]
    public IEnumerator HealthIsZeroPlayer()
    {
        var gameObject = new GameObject();
        gameObject.tag = "Player";
        var health = gameObject.AddComponent<Health>();
        health.TakeDamage(100);
        yield return null;
        Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator HealPlayerWhenHealthIsLessThanMaxHealth()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.health = 50;
        health.HealPlayer(20);
        yield return null;
        Assert.AreEqual(70, health.health);
    }

    [UnityTest]
    public IEnumerator HealPlayerWhenHealthIsGreaterThanMaxHealth()
    {
        var gameObject = new GameObject();
        var health = gameObject.AddComponent<Health>();
        health.HealPlayer(20);
        yield return null;
        Assert.AreEqual(100, health.health);
    }

    [UnityTest]
    public IEnumerator MainMenuLoadGame()
    {
        var gameObject = new GameObject();
        var menu = gameObject.AddComponent<Mainmenu>();
        menu.PlayGame();
        yield return null;
        Assert.AreEqual("1", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(1);
    }

    [UnityTest]
    public IEnumerator FireShootBulletCreation()
    {
        var gameObject = new GameObject();
        var fire = gameObject.AddComponent<Fire>();
        fire.bullet = new GameObject();
        fire.Fireposition = (new GameObject()).transform;
        fire.Shoot();
        yield return null;
        Assert.AreEqual(1, fire.bullets.Count);
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
        yield return null;
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
        yield return null;
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
        yield return null;
        Assert.AreEqual(1, testObjectsCountAfterSpawnDroppedItem - testObjectsCountBeforeSpawnDroppedItem);
    }

    [UnityTest]
    public IEnumerator FlyObjectDieWhenTrigger()
    {
        var bullet = CreateGameObjectWithCollider(true);
        bullet.AddComponent<Fly>();
        var objForCollision = CreateGameObjectWithCollider(false);
        bullet.transform.position = new Vector2(0, 0);
        objForCollision.transform.position = new Vector2(0, 0);
        yield return null;
        Assert.That(bullet == null);
    }
}
