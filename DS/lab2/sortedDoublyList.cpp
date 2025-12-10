#include <iostream>
using namespace std;

typedef struct employee{
    int id;
    string name;
    int age;
    double salary;
} Employee;

class node{
public:
    Employee data;
    node* next;
    node* prev;

    node(Employee emp) : data(emp), next(nullptr), prev(nullptr) {}
    ~node() {}
};

class SortedDoublyList{
private:
    node* head;
    node* tail;

protected:
    void insertAtHead(Employee emp){
        node* newNode = new node(emp);
        if(isEmpty()){
            head = tail = newNode;
        } else{
            newNode->next = head;
            head->prev = newNode;
            head = newNode;
        }
    }

    void insertAtTail(Employee emp){
        node* newNode = new node(emp);
        if(isEmpty()){
            head = tail = newNode;
        } else{
            tail->next = newNode;
            newNode->prev = tail;
            tail = newNode;
        }
    }

public:
    SortedDoublyList() : head(nullptr), tail(nullptr) {}

    SortedDoublyList(const SortedDoublyList& other) {
        head = nullptr;
        tail = nullptr;
        node* current = other.head;
        while (current != nullptr) {
            insertAtTail(current->data);
            current = current->next;
        }
    }

    ~SortedDoublyList() {
        node* current = head;
        while (current != nullptr) {
            node* nextNode = current->next;
            delete current;
            current = nextNode;
        }
    }

    bool isEmpty(){
        return head == nullptr && tail == nullptr;
    }

    void insertInOrder(Employee emp){
        node* newNode = new node(emp);
        if(isEmpty()){
            head = tail = newNode;
            return;
        }
        if(emp.id < head->data.id){
            insertAtHead(emp);
            return;
        }
        if(emp.id > tail->data.id){
            insertAtTail(emp);
            return;
        }
        node* current = head;
        while(current != nullptr && current->data.id < emp.id){
            current = current->next;
        }
        newNode->next = current;
        newNode->prev = current->prev;
        if(current->prev != nullptr){
            current->prev->next = newNode;
        }
        current->prev = newNode;
    }

    bool deleteById(int id){
        node* current = head;
        while(current != nullptr){
            if(current->data.id == id){
                if(current->prev != nullptr){
                    current->prev->next = current->next;
                } else {
                    head = current->next;
                }
                if(current->next != nullptr){
                    current->next->prev = current->prev;
                } else {
                    tail = current->prev;
                }
                delete current;
                return true;
            }
            if(current->data.id > id){
                break;
            }
            current = current->next;
        }
        return false;
    }

    node* searchById(int id){
        node* current = head;
        while(current != nullptr){
            if(current->data.id == id){
                return current;
            }
            if(current->data.id > id){
                break;
            }
            current = current->next;
        }
        return nullptr;
    }

    int count(){
        int count = 0;
        node* current = head;
        while(current != nullptr){
            count++;
            current = current->next;
        }
        return count;
    }

    void displayById(int id){
        node* empNode = searchById(id);
        if(empNode != nullptr){
            cout << "ID: " << empNode->data.id << ", Name: " << empNode->data.name 
                 << ", Age: " << empNode->data.age << ", Salary: " << empNode->data.salary << endl;
        } else {
            cout << "Employee with ID " << id << " not found." << endl;
        }
    }

    void displayAll(){
        node* current = head;
        while(current != nullptr){
            cout << "ID: " << current->data.id << ", Name: " << current->data.name 
                 << ", Age: " << current->data.age << ", Salary: " << current->data.salary << endl;
            current = current->next;
        }
    }

    Employee& operator[] (int index){
        node* current = head;
        int count = 0;
        while(current != nullptr){
            if(count == index){
                return current->data;
            }
            count++;
            current = current->next;
        }
        throw out_of_range("Index out of range");
    }

    SortedDoublyList& operator= (const SortedDoublyList& other){
        if(this == &other){
            return *this;
        }
        // Clear existing list
        this->~SortedDoublyList();
        head = tail = nullptr;

        node* current = other.head;
        while(current != nullptr){
            insertAtTail(current->data);
            current = current->next;
        }
        return *this;
    }
};

int main() {
    SortedDoublyList list;

    // Create some employees 
    Employee e1 = {3, "Ali", 25, 5000};
    Employee e2 = {1, "Sara", 30, 7000};
    Employee e3 = {5, "Omar", 28, 6000};
    Employee e4 = {2, "Mona", 35, 9000};
    Employee e5 = {4, "Khaled", 22, 4500};

    // Test insertInOrder 
    list.insertInOrder(e1);
    list.insertInOrder(e2);
    list.insertInOrder(e3);
    list.insertInOrder(e4);
    list.insertInOrder(e5);

    cout << "\nAll employees (sorted by ID):\n";
    list.displayAll();

    // Test searchById 
    cout << "\nSearch for ID 3:\n";
    node* found = list.searchById(3);
    if(found)
        cout << "Found: " << found->data.name << endl;
    else
        cout << "Not found.\n";

    // Test deleteById 
    cout << "\nDeleting ID 2...\n";
    bool deleted = list.deleteById(2);
    cout << (deleted ? "Deleted.\n" : "Not found.\n");

    cout << "\nAfter deletion:\n";
    list.displayAll();

    // Test count 
    cout << "\nNode count = " << list.count() << endl;

    // Test operator[]
    cout << "\nEmployee at index 1:\n";
    try {
        Employee &ref = list[1];
        cout << ref.id << " - " << ref.name << endl;
    } catch(const exception &e) {
        cout << e.what() << endl;
    }

    // Test copy constructor
    cout << "\nCreating copy using copy constructor...\n";
    SortedDoublyList listCopy = list;
    listCopy.displayAll();

    // Test assignment operator
    cout << "\nCreating another list using assignment...\n";
    SortedDoublyList listAssign;
    listAssign = list;
    listAssign.displayAll();

    return 0;
}
