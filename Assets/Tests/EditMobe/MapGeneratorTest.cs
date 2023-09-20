using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MapGeneratorTest
{
    
    [Test]
    public void GeneraitMap_size7_return49Count()
    {
        int size = 7;
        GameObject prefab = new GameObject();
        float step = Constants.STEP;
        int expected = 49;

        MapGenerator mapGenerator = new MapGenerator();
        int result = mapGenerator.GeneraitMap(prefab, size, step).Count;

        Assert.AreEqual(expected, result);
    }

    
}
