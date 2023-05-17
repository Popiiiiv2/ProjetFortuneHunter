using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlateau
{

    private Case cases;
    private Plateau plateau;

    [SetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        plateau = go.AddComponent<Plateau>();
    }

    /*[TearDown]
    public void TearDown()
    {
        plateau = null;
    }*/


    [Test]
    public void testCreerCases(){
        plateau.creerCases();
        Debug.Log(plateau);
        Assert.AreEqual(plateau.getCases().Length, 32);
    }

}
