using System;
using System.ComponentModel;
using NUnit.Framework;

//using HashTable = System.Collections.Generic.Dictionary<object, object>;

namespace HashTable
{
    [TestFixture]
    public class HashTableTests
    {
        /// <summary>
        /// Добавление трёх элементов, поиск трёх элементов
        /// </summary>
        [Test]
        public void AddingThreeElementsTest()
        {
            var element1 = 123;
            var element2 = "element2";
            var element3 = true;
            var key1 = "element";
            var key2 = false;
            var key3 = 123;
            var ht = new HashTable(3);
            ht.PutPair(key1, element1);
            ht.PutPair(key2, element2);
            ht.PutPair(key3, element3);
            Assert.AreEqual(element1, ht.GetValueByKey(key1));
            Assert.AreEqual(element2, ht.GetValueByKey(key2));
            Assert.AreEqual(element3, ht.GetValueByKey(key3));
        }

        /// <summary>
        /// Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
        /// </summary>
        [Test]
        public void AddingSameElementTwiceTest()
        {
            var element2 = "previous";
            var newValue = "next";
            var key2 = 0;
            var ht = new HashTable(3);
            ht.PutPair(key2, element2);
            ht.PutPair(key2, newValue);
            Assert.AreEqual(newValue, ht.GetValueByKey(key2));
        }

        /// <summary>
        ///  Добавление 10000 элементов в структуру и поиск одного из них
        /// </summary>
        [Test]
        public void ThousandsElementsTest()
        {
            int findingKey = 0;
            int findingElement = 0;
            int flag;
            var size = 10000;
            var rnd = new Random(10);
            flag = rnd.Next(size);
            var ht = new HashTable(size);
            for (var i = 0; i < size; i++)
            {
                var element = rnd.Next();
                var key = rnd.Next();
                ht.PutPair(key, element);
                if (i == flag)
                {
                    findingElement = element;
                    findingKey = key;
                }
            }
            Assert.AreEqual(findingElement, ht.GetValueByKey(findingKey));
        }


        /// <summary>
        /// Добавление 10000 элементов в структуру и поиск 1000 недобавленных ключей, поиск которых должен вернуть null
        /// </summary>
        [Test]
        public void FindingAlienKeys()
        {
            int flag;
            var size = 10000;
            var rnd = new Random(270005);
            flag = rnd.Next(size);
            var ht = new HashTable(size);
            for (var i = 0; i < size; i++)
            {
                var element = rnd.Next();
                ht.PutPair(i, element);
            }
            for (var i = 0; i < 1000; i++)
                Assert.AreEqual(null, ht.GetValueByKey(rnd.Next(1000) + 10000));
        }

    }
}
