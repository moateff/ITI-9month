#include <iostream>
#include <vector>
#include <list>
#include <stdexcept>
#include <functional>
using namespace std;

template<typename K, typename V>
class HashTable {
private:
    struct HashEntry {
        K key;
        V value;

        HashEntry(const K& k, const V& v)
            : key(k), value(v) {}
    };

    static constexpr double DEFAULT_LOAD_FACTOR = 0.75;
    static constexpr size_t INITIAL_CAPACITY = 7;

    vector<list<HashEntry>> table;
    size_t _size;
    size_t _capacity;
    double _maxLoadFactor;

    size_t hashKey(const K& key) const {
        return hash<K>{}(key) % _capacity;
    }

    void rehash() {
        size_t newCapacity = _capacity * 2;
        vector<list<HashEntry>> newTable(newCapacity);

        for (const auto& bucket : table) {
            for (const auto& entry : bucket) {
                size_t index = static_cast<size_t>(entry.key) % newCapacity;
                newTable[index].emplace_back(entry.key, entry.value);
            }
        }

        _capacity = newCapacity;
        table = move(newTable);
    }

    void checkLoadFactor() {
        if (loadFactor() > _maxLoadFactor)
            rehash();
    }

public:
    explicit HashTable(size_t capacity = INITIAL_CAPACITY,
                       double loadFactor = DEFAULT_LOAD_FACTOR)
        : _size(0), _capacity(capacity), _maxLoadFactor(loadFactor) {

        if (_capacity == 0)
            throw invalid_argument("Capacity must be > 0");

        if (_maxLoadFactor <= 0.0 || _maxLoadFactor > 1.0)
            throw invalid_argument("Invalid load factor");

        table.resize(_capacity);
    }

    // basic properties
    size_t size() const { return _size; }
    size_t capacity() const { return _capacity; }
    bool empty() const { return _size == 0; }

    double loadFactor() const {
        return static_cast<double>(_size) / _capacity;
    }

    // core operations
    bool contains(const K& key) const {
        size_t index = hashKey(key);
        for (const auto& entry : table[index]) {
            if (entry.key == key)
                return true;
        }
        return false;
    }

    bool insert(const K& key, const V& value) {
        size_t index = hashKey(key);

        for (auto& entry : table[index]) {
            if (entry.key == key) {
                cout << "Duplicate key: " << key << endl;
                return false;   // duplicate key
            }
        }

        table[index].emplace_back(key, value);
        ++_size;

        checkLoadFactor();
        return true;
    }

    bool remove(const K& key) {
        size_t index = hashKey(key);
        auto& bucket = table[index];

        for (auto it = bucket.begin(); it != bucket.end(); ++it) {
            if (it->key == key) {
                bucket.erase(it);
                --_size;
                return true;
            }
        }
        return false;
    }

    const V& lookUp(const K& key) const {
        size_t index = hashKey(key);
        for (auto& entry : table[index]) {
            if (entry.key == key)
                return entry.value;
        }
        throw out_of_range("Key not found");
    }

    void clear() {
        table.clear();
        table.resize(_capacity);
        _size = 0;
    }

    void print() const {
        for (size_t i = 0; i < _capacity; ++i) {
            cout << i << ": ";
            for (const auto& entry : table[i]) {
                cout << "(" << entry.key << ", "
                     << entry.value << ") -> ";
            }
            cout << "null\n";
        }
    }
};

int main() {
    HashTable<int, string> ht;

    cout << "Is hash table empty? " << (ht.empty() ? "Yes" : "No") << endl;

    cout << "Inserting elements...\n";
    ht.insert(1, "One");
    ht.insert(2, "Two");
    ht.insert(3, "Three");
    ht.insert(3, "abc");    // duplicate key test
    ht.insert(10, "Ten");   // collision test

    cout << "\nHash Table Contents:\n";
    ht.print();

    cout << "\nSize: " << ht.size() << endl;
    cout << "Capacity: " << ht.capacity() << endl;
    cout << "Load factor: " << ht.loadFactor() << endl;

    cout << "\nValue for key 2: " << ht.lookUp(2) << endl;

    try {
        ht.lookUp(5);  // non-existing key test
    } catch (const out_of_range& e) {
        cout << "Exception caught: " << e.what() << endl;
    }

    ht.remove(3);
    cout << "\nAfter removing key 3:\n";
    ht.print();

    ht.clear();
    cout << "\nAfter clearing the hash table:\n";
    ht.print();

    return 0;
}
