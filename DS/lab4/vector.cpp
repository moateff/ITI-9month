#include <iostream>
using namespace std;

template <typename T>
class Vector {
private:
    T* _data;
    size_t _size;
    size_t _capacity;

    void reallocate(size_t new_capacity) {
        T* new_data = new T[new_capacity];
        for (size_t i = 0; i < _size; i++)
            new_data[i] = move(_data[i]);
        
        delete[] _data;
        _data = new_data;
        _capacity = new_capacity;
    }
     
public:
    // constructors & destructor
    Vector() : _data(nullptr), _size(0), _capacity(0) {}

    explicit Vector(size_t size, const T& value = T())
        : _data(new T[_capacity]), _size(size), _capacity(size)
    {
        for (size_t i = 0; i < _size; i++)
            _data[i] = value;
    }
    
    Vector(initializer_list<T> list)
        : _data(new T[list.size()]), _size(list.size()), _capacity(list.size())
    {
        size_t i = 0;
        for (const auto& value : list)
            _data[i++] = value;
    }

    Vector(const Vector& other)
        : _data(new T[other._capacity]), _size(other._size), _capacity(other._capacity)
    {
        for (size_t i = 0; i < _size; i++)
            _data[i] = other._data[i];
    }

    Vector(Vector&& other) noexcept
        : _data(other._data), _size(other._size), _capacity(other._capacity)
    {
        other._data = nullptr;
        other._size = 0;
        other._capacity = 0;
    }

    ~Vector() {
        delete[] _data;
        _data = nullptr;
        _size = 0;
        _capacity = 0;
    }

    // assignment operators
    Vector& operator=(const Vector& other) {
        if (this != &other) {
            delete[] _data;

            _size = other._size;
            _capacity = other._capacity;

            _data = new T[_capacity];
            for (size_t i = 0; i < _size; i++)
                _data[i] = other._data[i];
        }
        return *this;
    }

    Vector& operator=(Vector&& other) noexcept {
        if (this != &other) {
            delete[] _data;
            _data = other._data;
            _size = other._size;
            _capacity = other._capacity;

            other._data = nullptr;
            other._size = 0;
            other._capacity = 0;
        }
        return *this;
    }

    // element access
    T& operator[](size_t index) {
        return _data[index];
    }

    T& at(size_t index) {
        if (index >= _size) 
            throw out_of_range("Index out of range");
        
        return _data[index];
    }

    const T& operator[](size_t index) const {
        return _data[index];
    }
    
    T& front() { return _data[0]; }
    T& back() { return _data[_size - 1]; }
    T* data() { return _data; }

    // iterators
    T* begin() { return _data; }
    T* end() { return _data + _size; }

    // capacity
    size_t size() const { return _size; }
    size_t capacity() const { return _capacity; }
    bool empty() const { return _size == 0; }

    void reserve(size_t new_capacity) {
        if (new_capacity > _capacity)
            reallocate(new_capacity);
    }

    void resize(size_t new_size, const T& value = T()) {
        if (new_size > _capacity)
            reserve(new_size);
        
        if (new_size > _size) {
            for(size_t i = _size; i < new_size; i++)
                _data[i] = value;
            
        }
        _size = new_size;
    }

    // modifiers
    void push_back(const T value) {
        if (_size == _capacity) 
            reserve(_capacity == 0 ? 1 : _capacity * 2);
        _data[_size++] = value;
    }

    void pop_back() {
        if (_size > 0)
            _size--;
    }

    void insert(size_t pos, const T& value) {
        if (pos > _size)
            throw out_of_range("Insert position invalid");
        
        if (_size == _capacity) 
            reserve(_capacity == 0 ? 1 : _capacity * 2);
        
        for (size_t i = _size; i > pos; i--)
            _data[i] = move(_data[i-1]);
        
        _data[pos] = value;
        _size++;
    }

    void eraseAt(size_t pos) {
        if (pos > _size)
            throw out_of_range("Erase position invalid");

        for (size_t i = pos; i < _size-1; i++)
            _data[i] = move(_data[i+1]);
        
        _size--;
    }
    
    void erase(const T& value) {
        for (size_t i = 0; i < _size; i++) {
            if (_data[i] == value) {
                for (size_t j = i; j < _size-1; j++)
                    _data[j] = move(_data[j+1]);

                _size--;  
                return;
            }
        } 
    }
    /*
    void erase(const T& value) {
        size_t j = 0;
        for (size_t i = 0; i < _size; i++) {
            if (!(_data[i] == value)) {
                _data[j++] = move(_data[i]);
            }
        }
        _size = j;   
    }
    */
    void clear() {
        _size = 0;
    }

    void display() const {
        for (size_t i = 0; i < _size; i++)
            cout << _data[i] << " ";
        cout << endl;
    }

    /*
    bool operator==(const Vector& other) {
        if (this != &other) {
            if (_size != other._size)
                return false;

            for (size_t i = 0; i < _size; i++) {
                if (_data[i] != other._data[i])
                    return false;
            }
        }
        return true;
    }
    */
};

int main() {
    Vector<string> v;

    cout << "Is vector empty? " << (v.empty() ? "Yes" : "No") << endl;

    // push_back
    v.push_back("Alice");
    v.push_back("Bob");
    v.push_back("Charlie");

    cout << "\nAfter push_back:\n";
    v.display();

    cout << "Size: " << v.size() << ", Capacity: " << v.capacity() << endl;

    // insert
    v.insert(1, "Eve");
    cout << "\nAfter insert at position 1:\n";
    v.display();

    // erase by value
    v.erase("Bob");
    cout << "\nAfter erase(\"Bob\"):\n";
    v.display();

    // eraseAt
    v.eraseAt(0);
    cout << "\nAfter eraseAt(0):\n";
    v.display();

    // front & back
    cout << "\nFront: " << v.front() << endl;
    cout << "Back: " << v.back() << endl;

    // resize (grow)
    v.resize(5, "Default");
    cout << "\nAfter resize to 5 with default value:\n";
    v.display();

    // resize (shrink)
    v.resize(2);
    cout << "\nAfter resize to 2:\n";
    v.display();


    // copy constructor
    Vector<string> copyVec(v);
    cout << "\nCopied vector:\n";
    copyVec.display();

    // move constructor
    Vector<string> movedVec(move(v));
    cout << "\nMoved vector:\n";
    movedVec.display();

    cout << "Original vector size after move: " << v.size() << endl;

    // clear
    movedVec.clear();
    cout << "\nAfter clear(), is empty? "
         << (movedVec.empty() ? "Yes" : "No") << endl;

    // bounds check
    try {
        cout << v.at(10) << endl;
    } catch (const out_of_range& e) {
        cout << "\nException caught: " << e.what() << endl;
    }

    return 0;
}


