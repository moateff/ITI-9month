#include <iostream>
using namespace std;

class Stack {
private:
    int* arr;   // pointer to dynamic array
    int tos;    // top of stack index
    int size;   // maximum size of stack

public:
    Stack(int _size = 5) {
        size = _size;
        arr = new int[_size];
        tos = -1; // stack initially empty

        cout << "Single parameter constructor called" << endl;
    }
    
    // Copy constructor
    Stack(const Stack& s) {
        size = s.size;
        tos = s.tos;

        // allocate new memory
        arr = new int[size];

        // copy elements
        for (int i = 0; i <= tos; i++) {
            arr[i] = s.arr[i];
        }

        cout << "Copy constructor called" << endl;
    }
    
    // Destructor
    ~Stack() {
        for (int i = 0; i <= tos; i++) {
            arr[i] = -1;  
        }

        delete[] arr;
        arr = NULL;

        cout << "Destructor called, memory freed" << endl;
    }

    // Check if stack is full
    bool isFull() const {
        return tos == size - 1;
    }

    // Check if stack is empty
    bool isEmpty() const {
        return tos == -1;
    }

    // Push a value onto the stack
    void push(int value) {
        if (isFull()) {
            cout << "Stack overflow! Cannot push " << value << endl;
        } else {
            arr[++tos] = value;
        }
    }

    // Pop a value and return it
    int pop() {
        if (isEmpty()) {
            cout << "Stack underflow! Returning -1" << endl;
            return -1;
        } else {
            return arr[tos--];
        }
    }

    // Return the top element without removing it
    int peek() const {
        if (isEmpty()) {
            cout << "Stack is empty! Returning -1" << endl;
            return -1;
        }
        return arr[tos];
    }

    // Return count of elements in stack
    int getCount() const {
        return tos + 1;
    }

    // Returns a new Stack with elements in reversed order
    Stack reverse() const {
        Stack reversed(size);           
        for (int i = tos; i >= 0; i--) {
            reversed.push(arr[i]);     
        }
        return reversed;
    }

    friend void viewContentByValue(const Stack s);
    friend void viewContentByReference(const Stack& s);
};

// View content 
// Pass by value
void viewContentByValue(const Stack s) {
    cout << "Stack content (by value): ";
    for (int i = 0; i <= s.tos; i++) {
        cout << s.arr[i] << " ";
    }
    cout << endl;
}

// Pass by refernence 
void viewContentByReference(const Stack& s) {
    cout << "Stack content (by reference): ";
    for (int i = 0; i <= s.tos; i++) {
        cout << s.arr[i] << " ";
    }
    cout << endl;
}

int main() {
    Stack s(7);

    s.push(3);
    s.push(4);
    s.push(5);

    viewContentByValue(s); 
    viewContentByReference(s); 

    Stack rs = s.reverse();

    viewContentByValue(rs); 
    viewContentByReference(rs); 

    return 0;
}
