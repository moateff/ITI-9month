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
    }
    
    // Copy constructor
    Stack(const Stack& s) {
        size = s.size;
        tos = s.tos;
        arr = new int[size];

        // copy elements
        for (int i = 0; i <= tos; i++) {
            arr[i] = s.arr[i];
        }
    }

    // Destructor
    ~Stack() {
        for (int i = 0; i <= tos; i++) {
            arr[i] = -1;  
        }

        delete[] arr;
        arr = NULL;
    }

    bool isFull() const { return tos == size - 1; }
    bool isEmpty() const { return tos == -1; }

    void push(int value) {
        if (isFull()) {
            cout << "Stack overflow! Cannot push " << value << endl;
        } else {
            arr[++tos] = value;
        }
    }

    int pop() {
        if (isEmpty()) {
            cout << "Stack underflow! Returning -1" << endl;
            return -1;
        } else {
            return arr[tos--];
        }
    }

    int peek() const {
        if (isEmpty()) {
            cout << "Stack is empty! Returning -1" << endl;
            return -1;
        }
        return arr[tos];
    }

    int getCount() const { return tos + 1; }

    Stack reverse() const {
        Stack reversed(size);           
        for (int i = tos; i >= 0; i--) {
            reversed.push(arr[i]);     
        }
        return reversed;
    }

    // stack=stack
    Stack& operator=(const Stack& s) {
        if (this == &s)       // self-assignment check
            return *this;

        delete[] arr;         // delete old memory

        size = s.size;
        tos = s.tos;

        arr = new int[size];  // allocate new memory

        for (int i = 0; i <= tos; i++)
            arr[i] = s.arr[i];

        return *this;
    }

    // stack+stack
    Stack operator+(const Stack& s) const {
        Stack result(size + s.size);

        // copy first stack elements
        for (int i = 0; i <= tos; i++)
            result.push(arr[i]);

        // append second stack elements
        for (int i = 0; i <= s.tos; i++)
            result.push(s.arr[i]);

        return result;
    }

    // stack[i]
    int& operator[](int index) {
        if (index < 0 || index > tos) {
            cout << "Index out of range! Returning arr[0]." << endl;
            return arr[0];   // safe fallback
        }
        return arr[index];
    }

    const int& operator[](int index) const {
        if (index < 0 || index > tos) {
            cout << "Index out of range! Returning arr[0]." << endl;
            return arr[0];
        }
        return arr[index];
    }

    friend void viewContent(const Stack& s) {
        cout << "Stack content : ";
        for (int i = 0; i <= s.tos; i++) {
            cout << s.arr[i] << " ";
        }
        cout << endl;
    }
};

int main() {
    Stack s1(5);
    s1.push(10);
    s1.push(20);
    s1.push(30);

    cout << "s1 after pushes: ";
    viewContent(s1);
    cout << endl;

    // Copy constructor test
    Stack s2 = s1;
    cout << "s2 (copied from s1): ";
    viewContent(s2);
    cout << endl;

    // Operator =
    Stack s3(10);
    s3.push(100);
    s3.push(200);

    cout << "s3 before assignment: ";
    viewContent(s3);

    s3 = s1;  
    cout << "s3 after s3 = s1: ";
    viewContent(s3);
    cout << endl;

    // Operator +
    Stack s4 = s1 + s3;
    cout << "s4 = s1 + s3: ";
    viewContent(s4);
    cout << endl;

    // Operator []
    cout << "s1[1] = " << s1[1] << endl;
    s1[1] = 999;   // modify element
    cout << "s1 after s1[1] = 999: ";
    viewContent(s1);
    cout << endl;

    // Reverse stack
    Stack s5 = s1.reverse();
    cout << "s5 (reverse of s1): ";
    viewContent(s5);
    cout << endl;

    // Pop and peek
    cout << "Popped from s1: " << s1.pop() << endl;
    cout << "Peek on s1: " << s1.peek() << endl;

    cout << "Final state of s1: ";
    viewContent(s1);

    return 0;
}
