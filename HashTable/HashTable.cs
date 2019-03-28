using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable
    {
        private List<HashPair>[] table;
        class HashPair
        {
            public int Key;
            public object Value;
            public HashPair(int key, object value)
            {
                Key = key;
                Value = value;
            }
        }

        /// <summary>
        /// Конструктор контейнера
        /// <summary>
        /// size">Размер хэ-таблицы
        public HashTable(int size)
        {
            table = new List<HashPair>[size];
        }



        ///
        /// Метод складывающий пару ключ-значение в таблицу
        ///
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            var hashCode = key.GetHashCode();
            var ind = Math.Abs(hashCode) % table.Length;
            if (table[ind] == null)
            {
                table[ind] = new List<HashPair> { new HashPair(hashCode, value) };
            }
            else
            {
                var trigger = true;
                foreach (var e in table[ind])
                {
                    if (e.Key == hashCode)
                    {
                        e.Value = value;
                        trigger = false;
                        break;
                    }
                }
                if (trigger) table[ind].Add(new HashPair(hashCode, value));
            }
        }



        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствует returns>
        public object GetValueByKey(object key)
        {
            try
            {
                var seekingHashCode = key.GetHashCode();
                var seekingValue = table[Math.Abs(seekingHashCode) % table.Length];
                return seekingValue.Find(x => x.Key == seekingHashCode).Value;
            }
            catch
            {
                return null;
            }


        }

    }
}
