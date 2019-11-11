using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        public SpawnerScript spawner;
        public PlayerShoot shoot;
        public GameObject theObject;

        [SetUp]
        public void Setup()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Game");
            theObject = Object.Instantiate(prefab);
            shoot = theObject.GetComponentInChildren<PlayerShoot>();
        }

        [UnityTest]
        public IEnumerator GameExists()
        {
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(null != theObject, "No nothing");
        }

        [UnityTest]
        public IEnumerator PlayerShoot()
        {
            shoot.RealShoot();
            yield return new WaitForFixedUpdate();
            GameObject bullet = Object.FindObjectOfType<Bullet>().gameObject;
            Assert.IsTrue(bullet != null,"NO BULLET");
        }

        [UnityTest]
        public IEnumerator BulletMoves()
        {
            shoot.RealShoot();
            yield return new WaitForEndOfFrame();
            GameObject bullet = Object.FindObjectOfType<Bullet>().gameObject;
            float firstPos = bullet.transform.position.z;
            yield return new WaitForEndOfFrame();
            Assert.Greater(bullet.transform.position.z, firstPos, "BULLET WON'T MOVE");
        }

        [UnityTest]
        public IEnumerator SchnozSpawns()
        {
            spawner.RealSpawn();
            yield return new WaitForFixedUpdate();
            GameObject schnoz = Object.FindObjectOfType<Schnoz>().gameObject;
            Assert.IsTrue(schnoz != null, "NO SCHNOZ");
        }

        [UnityTest]
        public IEnumerator SchnozFalls()
        {
            spawner.RealSpawn();
            yield return new WaitForEndOfFrame();
            GameObject schnoz = Object.FindObjectOfType<Schnoz>().gameObject;
            float firstPos = schnoz.transform.position.y;
            yield return new WaitForSeconds(2);
            Assert.Greater(schnoz.transform.position.y, firstPos, "SCHNOZ WON'T MOVE! HE'S DEAD!!");
        }


        [TearDown]
        public void TearDown()
        {
            Object.Destroy(theObject.gameObject);
        }
    }
}
