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
};

class DoublyList{
private:
    node* head;
    node* tail;

public:
    DoublyList() : head(nullptr), tail(nullptr) {}
    DoublyList(const DoublyList& other) {
        head = nullptr;
        tail = nullptr;
        node* current = other.head;
        while (current != nullptr) {
            insertAtTail(current->data);
            current = current->next;
        }
    }

    ~DoublyList() {
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

    void insertOnPosition(Employee emp, int position){
        if(position <= 0){
            insertAtHead(emp);
            return;
        }
        node* newNode = new node(emp);
        node* current = head;
        int index = 0;
        while(current != nullptr && index < position){
            current = current->next;
            index++;
        }
        if(current == nullptr){
            insertAtTail(emp);
            return;
        }
        newNode->next = current;
        newNode->prev = current->prev;
        if(current->prev != nullptr){
            current->prev->next = newNode;
        } else{
            head = newNode;
        }
        current->prev = newNode;
    }

    bool deleteById(int id){
        node* current = head;
        while(current != nullptr){
            if(current->data.id == id){
                if(current->prev != nullptr){
                    current->prev->next = current->next;
                } else{
                    head = current->next;
                }
                if(current->next != nullptr){
                    current->next->prev = current->prev;
                } else{
                    tail = current->prev;
                }
                delete current;
                return true;
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
            current = current->next;
        }
        return nullptr;
    }

    int nodeCount(){
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
        } else{
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

    DoublyList& operator= (const DoublyList& other){
        if(this == &other){
            return *this;
        }
        // Clear existing list
        this->~DoublyList();
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
    DoublyList list;

    // Sample employees
    Employee e1 = {1, "Ali", 23, 5000};
    Employee e2 = {2, "Mona", 30, 6200};
    Employee e3 = {3, "Omar", 27, 4500};
    Employee e4 = {4, "Sara", 29, 7000};
    Employee e5 = {5, "Khaled", 22, 3800};

    cout << "\n Testing insertAtHead \n";
    list.insertAtHead(e3);  // 3
    list.insertAtHead(e2);  // 2 3
    list.insertAtHead(e1);  // 1 2 3
    list.displayAll();

    cout << "\n Testing insertAtTail \n";
    list.insertAtTail(e4);  // 1 2 3 4
    list.displayAll();

    cout << "\n Testing insertOnPosition \n";
    list.insertOnPosition(e5, 2); // insert at pos 2 → 1 2 (5) 3 4
    list.displayAll();

    cout << "\n Testing searchById (search ID 3) \n";
    node* found = list.searchById(3);
    if (found)
        cout << "Found: " << found->data.name << endl;
    else
        cout << "Not found.\n";

    cout << "\n Testing deleteById (delete ID 2) \n";
    bool deleted = list.deleteById(2);
    cout << (deleted ? "Deleted successfully.\n" : "Employee not found.\n");

    cout << "\nList after deletion:\n";
    list.displayAll();

    cout << "\n Testing nodeCount \n";
    cout << "Nodes: " << list.nodeCount() << endl;

    cout << "\n Testing displayById (ID 4) \n";
    list.displayById(4);

    cout << "\n Testing operator[] (index 1) \n";
    try {
        Employee &emp = list[1];
        cout << "Employee at index 1 → " << emp.id << ", " << emp.name << endl;
    } catch (const exception& e) {
        cout << e.what() << endl;
    }

    cout << "\n Testing Copy Constructor \n";
    DoublyList copiedList(list);
    copiedList.displayAll();

    cout << "\n Testing Assignment Operator \n";
    DoublyList assignedList;
    assignedList = list;
    assignedList.displayAll();

    return 0;
}
