#include <iostream>
#include <algorithm>
using namespace std;

class AVLBinarySearchTree{
private:
    struct Node{
        int data;
        Node* left;
        Node* right;
        int height;

        Node(int value)
            : data(value), left(nullptr), right(nullptr), height(0) {}    

    };

    int getHeight(Node* node) const {
        return node ? node->height : -1;
    }

    int getBalance(Node* node) const {
        return node ? getHeight(node->left) - getHeight(node->right) : 0;
    }

    void updateHeight(Node* node) {
        if (node) {
            int leftHeight = getHeight(node->left);
            int rightHeight = getHeight(node->right);
            node->height = 1 + max(leftHeight, rightHeight);
        }
    }

    Node* root;
    int nodeCount;


    Node* rightRotate(Node* x) {
        Node* y = x->left;
        x->left = y->right;
        y->right = x;

        updateHeight(x);
        updateHeight(y);

        return y;
    }

    Node* leftRotate(Node* x) {
        Node* y = x->right;
        x->right = y->left;
        y->left = x;

        updateHeight(x);
        updateHeight(y);

        return y;
    }

    Node* balance(Node* node) {
        if (node == nullptr) return node;

        int balance = getBalance(node);

        // Left heavy
        if (balance > 1) {
            // Left-Right case
            if (node->left && getBalance(node->left) < 0) {
                node->left = leftRotate(node->left);
            }
            // Left-Left case
            return rightRotate(node);
        }

        // Right heavy
        if (balance < -1) {
            // Right-Left case
            if (node->right && getBalance(node->right) > 0) {
                node->right = rightRotate(node->right);
            }
            // Right-Right case
            return leftRotate(node);
        }

        return node; // Already balanced
    }

    Node* insert(Node* node, int value) {
        if (node == nullptr) {
            nodeCount++;
            return new Node(value);
        }

        if (value < node->data) {
            node->left = insert(node->left, value);
        } else if (value > node->data) {
            node->right = insert(node->right, value);
        }

        // Update balance factor and height values.
        updateHeight(node);

        // Re-balance tree.
        return balance(node);
    }


    Node* findMax(Node* node) {
        if (node == nullptr) return node;
        while (node->right != nullptr) node = node->right;
        return node;
    }

    Node* findMin(Node* node) {
        if (node == nullptr) return node;
        while (node->left != nullptr) node = node->left;
        return node;
    }

    Node* remove(Node* node, int value) {
        if (node == nullptr) return node;
        if (value < node->data) {
            node->left = remove(node->left, value);
        } else if (value > node->data) {
            node->right = remove(node->right, value);
        } else {
            // Node with one child
            if (node->left == nullptr) {
                Node* temp = node->right;
                delete node;
                nodeCount--;
                return temp;
            } else if (node->right == nullptr) {
                Node* temp = node->left;
                delete node;
                nodeCount--;
                return temp;
            }

            // Node with two children
            if (node->left->height > node->right->height) {
                Node* temp = findMax(node->left);
                node->data = temp->data;
                node->left = remove(node->left, temp->data);
            } else {
                Node* temp = findMin(node->right);
                node->data = temp->data;
                node->right = remove(node->right, temp->data);
            }
        }

        // Update balance factor and height values.
        updateHeight(node);

        // Re-balance tree.
        return balance(node);
    }

    bool contains(Node* node, int value) const {
        if (node == nullptr) return false;
        if (value < node->data) return contains(node->left, value);
        else if (value > node->data) return contains(node->right, value);
        return true;
    } 

    void traverse(Node* node) const {
        if (node != nullptr) {
            traverse(node->left);
            cout << node->data << ' ';
            traverse(node->right);
        }
    }

    void destroy(Node* node) {
        if (node != nullptr) {
            destroy(node->left);
            destroy(node->right);
            delete node;
        }
    }

    Node* copy(Node* node) {
        if (node == nullptr) return nullptr;
        Node* newNode = new Node(node->data);
        newNode->left = copy(node->left);
        newNode->right = copy(node->right);
        updateHeight(newNode);
        return newNode;
    }

public:
    AVLBinarySearchTree() : root(nullptr), nodeCount(0) {}

    AVLBinarySearchTree(const AVLBinarySearchTree& other)
        : root(copy(other.root)), nodeCount(other.nodeCount) {}

    AVLBinarySearchTree& operator=(const AVLBinarySearchTree& other) {
        if (this != &other) {
            destroy(root);
            root = copy(other.root);
            nodeCount = other.nodeCount;
        }
        return *this;
    }

    ~AVLBinarySearchTree() {
        destroy(root);
    }

    bool insert(int value) {
        if (contains(root, value)) return false;
        root = insert(root, value);
        return true;
    }

    bool remove(int value) {
        if(!contains(root, value)) return false;
        root = remove(root, value);
        return true;
    }

    bool contains(int value) const {
        return contains(root, value);
    }

    int height() const {
        return getHeight(root);
    }

    int levels() const {
        return height() + 1;
    }

    int size() const {
        return nodeCount;
    }

    bool isEmpty() const {
        return size() == 0;
    }

    void display() const {
        traverse(root);
        cout << endl;
    }
};

int main() {
    AVLBinarySearchTree avl;

    // Insert elements
    int values[] = {60, 50, 40, 30, 20, 40, 10};
    for (int v : values) {
        avl.insert(v);
    }

    cout << "Inorder traversal (should be sorted): ";
    avl.display();

    cout << "Tree levels: " << avl.levels() << endl;
    cout << "Tree size: " << avl.size() << endl;

    // Search tests
    cout << "Contains 10? " << (avl.contains(10) ? "Yes" : "No") << endl;
    cout << "Contains 100? " << (avl.contains(100) ? "Yes" : "No") << endl;

    // Remove leaf node
    avl.remove(10);
    cout << "After removing 10: ";
    avl.display();

    // Remove node with one child
    avl.remove(50);
    cout << "After removing 50: ";
    avl.display();

    // Remove node with two children
    avl.remove(30);
    cout << "After removing 30 (root): ";
    avl.display();

    cout << "Final levels: " << avl.levels() << endl;
    cout << "Final size: " << avl.size() << endl;

    // Copy constructor test
    AVLBinarySearchTree avlCopy = avl;
    cout << "Copied tree inorder traversal: ";
    avlCopy.display();

    return 0;
}

