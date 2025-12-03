#include <iostream>
using namespace std;

class Base {
public:
    Base() { cout << "Base constructor\n"; }

    // virtual destructor
    virtual ~Base() { 
        cout << "Base destructor\n"; 
    }
};

class Derived : public Base {
private:
    int* data;

public:
    Derived() {
        data = new int[5];  // allocating dynamic resource
        cout << "Derived constructor (allocated memory)\n";
    }

    ~Derived() {
        delete[] data; 
        cout << "Derived destructor (freed memory)\n";
    }
};

int main() {
    Base* ptr = new Derived();  // Base pointer to Derived object

    cout << "\nDeleting object through Base pointer...\n";
    delete ptr;  // Calls Derived destructor THEN Base destructor

    return 0;
}
