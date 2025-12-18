#include <iostream>
#include <vector>
#include <list>
#include <stdexcept>
using namespace std;

template<typename K, typename V>
struct HashEntry {
    K _key;
    V _value;
    HashEntry(K k, V v) : _key(k), _value(v) {}

    K getKey() const { return _key; }
    V getValue() const { return _value; }
};

template<typename K, typename V>
class HashTable {
private:
};