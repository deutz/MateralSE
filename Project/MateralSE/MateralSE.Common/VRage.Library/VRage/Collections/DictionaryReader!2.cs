﻿namespace VRage.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DictionaryReader<K, V> : IEnumerable<KeyValuePair<K, V>>, IEnumerable
    {
        private readonly Dictionary<K, V> m_collection;
        public static readonly DictionaryReader<K, V> Empty;
        public DictionaryReader(Dictionary<K, V> collection)
        {
            this.m_collection = collection;
        }

        public bool IsValid =>
            (this.m_collection != null);
        public bool ContainsKey(K key) => 
            this.m_collection.ContainsKey(key);

        public bool TryGetValue(K key, out V value) => 
            this.m_collection.TryGetValue(key, out value);

        public int Count =>
            this.m_collection.Count;
        public V this[K key] =>
            this.m_collection[key];
        public IEnumerable<K> Keys =>
            this.m_collection.Keys;
        public IEnumerable<V> Values =>
            this.m_collection.Values;
        public Dictionary<K, V>.Enumerator GetEnumerator() => 
            this.m_collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator() => 
            this.GetEnumerator();

        public static implicit operator DictionaryReader<K, V>(Dictionary<K, V> v) => 
            new DictionaryReader<K, V>(v);

        static DictionaryReader()
        {
        }
    }
}

