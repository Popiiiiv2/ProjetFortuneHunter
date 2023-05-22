using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlateau
{
    private Plateau plateau;

    [SetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        plateau = go.AddComponent<Plateau>();
        plateau.creerCases();
    }

    [TearDown]
    public void TearDown()
    {
        plateau = null;
    }


    [Test]
    public void testCreerCases(){
        Assert.AreEqual(plateau.getCases().Length, 32);
    }

    [Test]
    public void testSetNumCase(){
        plateau.setNumCase();
        Assert.AreEqual(plateau.getCase(2).getNumCase(), 2);
    }

}
