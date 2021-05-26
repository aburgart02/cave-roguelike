using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class UnitTests
{
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
    public IEnumerator SpawnItem()
    {
        var gameObject = new GameObject();
        var spawn = gameObject.AddComponent<Spawn>();
        spawn.item = new GameObject();
        spawn.spawnPosition = (new GameObject()).transform;
        spawn.spawnPosition.position = new Vector2(1, 1);
        spawn.item.tag = "Test";
        var item = GameObject.FindWithTag("Test");
        spawn.SpawnDroppedItem();
        yield return null;
        Assert.That(item != null);
    }

    [UnityTest]
    public IEnumerator ShootsWithPeriod()
    {
        var gameObject = new GameObject();
        var periodShoot = gameObject.AddComponent<PeriodShoot>();
        periodShoot.bullet = new GameObject();
        periodShoot.firePoint = (new GameObject()).transform;
        periodShoot.bullet.tag = "Test";
        periodShoot.Shoot();
        var item = GameObject.FindWithTag("Test");
        yield return null;
        Assert.That(item != null);
    }
}
