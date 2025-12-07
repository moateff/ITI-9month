#include <iostream>
using namespace std;

class IntArray {
private:
    int* arr;   // pointer to dynamic a
    int size;   // maximum size of a

public:
    IntArray(int s = 5) {
        size = s;
        arr = new int[size];
    }

    IntArray(const IntArray& a) {
        size = a.size;
        arr = new int[size];

        for (int i = 0; i < a.size; ++i) {
            arr[i] = a.arr[i];
        }
    }

    ~IntArray(){
        delete[] arr;
        arr = NULL;
    }
 
    IntArray& operator=(const IntArray& a) {
        if (this == &a)       // self-assignment check
            return *this;

        delete[] arr;         // delete old memory

        size = a.size; /////////////////
        arr = new int[a.size];

        for (int i = 0; i < a.size; ++i) {
            arr[i] = a.arr[i];
        }

        return *this;
    }

    int& operator[](int i) {
        if (i < 0 || i >= size) {
            cout << "Index out of range! Returning arr[0]." << endl;
            return arr[0];
        }
        return arr[i];
    }

    IntArray operator+(const IntArray a) const {
        IntArray t(size + a.size);

        for (int i = 0; i < size; i++)
            t.arr[i] = arr[i];
        
        for (int i = 0; i < a.size; i++)
            t.arr[size + i] = a.arr[i];
        
        return t;
    }

    int GetSize() { return size; }
};

int main() {
    IntArray a1(5);

    for (int i = 0; i < a1.GetSize(); ++i) {
        a1[i] = (i + 1) * 10;    // 10, 20, 30, 40, 50
    }

    cout << "a1 content: ";
    for (int i = 0; i < a1.GetSize(); ++i) {
        cout << a1[i] << " ";
    }
    cout << endl;

    // Copy constructor
    IntArray a2 = a1;
    cout << "a2 (copied from a1): ";
    for (int i = 0; i < a2.GetSize(); ++i) {
        cout << a2[i] << " ";
    }
    cout << endl;

    // Assignment operator
    IntArray a3(3);
    a3 = a1;

    cout << "a3 (assigned from a1): ";
    for (int i = 0; i < a3.GetSize(); ++i) {
        cout << a3[i] << " ";
    }
    cout << endl;

    // Operator+
    IntArray a4 = a1 + a2;
    cout << "a4 = a1 + a2: ";
    for (int i = 0; i < a4.GetSize(); ++i) {
        cout << a4[i] << " ";
    }
    cout << endl;

    return 0;
}
