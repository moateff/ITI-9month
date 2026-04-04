#include <iostream>
using namespace std;

class Node{
public:
    int data;
    Node* left;
    Node* right;

    Node(int val) : data(val), left(nullptr), right(nullptr) {}
    ~Node(){}
};

class BinarySearchTree{
private:
    Node* root;

    Node* insertNode(Node* node, int val){
        if(node == nullptr){
            return new Node(val);
        }
        if(val < node->data){
            node->left = insertNode(node->left, val);
        } else if(val > node->data){
            node->right = insertNode(node->right, val);
        } else {
            throw invalid_argument("Duplicate values are not allowed");
        }
        return node;
    }

    Node* copyNode(Node* otherNode) {
        if (otherNode == nullptr) return nullptr;
        Node* newNode = new Node(otherNode->data);
        newNode->left = copyNode(otherNode->left);
        newNode->right = copyNode(otherNode->right);
        return newNode;
    }

    Node* minValueNode(Node* node){
        Node* current = node;
        while(current && current->left != nullptr){
            current = current->left;
        }
        return current;
    }

    Node* maxValueNode(Node* node){
        Node* current = node;
        while(current && current->right != nullptr){
            current = current->right;
        }
        return current;
    }

    Node* deleteNode(Node* node, int val){
        if(node == nullptr){
            return node;
        }
        if(val < node->data){
            node->left = deleteNode(node->left, val);
        } else if(val > node->data){
            node->right = deleteNode(node->right, val);
        } else{
            if(node->left == nullptr){
                Node* temp = node->right;
                delete node;
                return temp;
            } else if(node->right == nullptr){
                Node* temp = node->left;
                delete node;
                return temp;
            }
            Node* temp = minValueNode(node->right);
            node->data = temp->data;
            node->right = deleteNode(node->right, temp->data);
        }
        return node;
    }

    void traversePreOrder(Node* node){
        if(node != nullptr){
            cout << node->data << " ";
            traversePreOrder(node->left);
            traversePreOrder(node->right);
        }
    }

    void traverseInOrder(Node* node){
        if(node != nullptr){
            traverseInOrder(node->left);
            cout << node->data << " ";
            traverseInOrder(node->right);
        }
    }

    void traversePostOrder(Node* node){
        if(node != nullptr){
            traversePostOrder(node->left);
            traversePostOrder(node->right);
            cout << node->data << " ";
        }
    }

    void destroyNode(Node* node){
        if(node != nullptr){
            destroyNode(node->left);
            destroyNode(node->right);
            delete node;
        }
    }

    int countNodes(Node* node){
        if(node == nullptr){
            return 0;
        }
        return 1 + countNodes(node->left) + countNodes(node->right);
    }

    int countLeaves(Node* node) {
        if (node == nullptr) return 0;
        if (node->left == nullptr && node->right == nullptr) return 1;
        return countLeaves(node->left) + countLeaves(node->right);
    }

    int height(Node* node) {
        if (node == nullptr) return -1;
        int leftHeight = height(node->left);
        int rightHeight = height(node->right);
        return 1 + max(leftHeight, rightHeight);
    }

    bool isBalanced(Node* node) {
        if (node == nullptr) return true;
        int leftHeight = height(node->left);
        int rightHeight = height(node->right);
        if (abs(leftHeight - rightHeight) > 1) return false;
        return isBalanced(node->left) && isBalanced(node->right);
    }

public:
    BinarySearchTree() : root(nullptr) {}

    BinarySearchTree(const BinarySearchTree& other) {
        root = copyNode(other.root);
    }

    ~BinarySearchTree() {
        destroyTree();
    }

    bool isEmpty(){
        return root == nullptr;
    } 

    bool isBalanced(){
        return isBalanced(root);
    }

    void insertNode(int val){
        root = insertNode(root, val);
    }

    void display(){
        traversePreOrder(root);
        cout << endl;
    }

    int countNodes(){
        return countNodes(root);
    }

    int countLeaves() {
        return countLeaves(root);
    }

    int height() {
        return height(root);
    }

    void destroyTree() {
        destroyNode(root);
        root = nullptr;
    }

    void remove(int val) {
        root = deleteNode(root, val);
    }
};

int main() {
    BinarySearchTree bst;

    bst.insertNode(1);
    bst.insertNode(2);
    bst.insertNode(3);
    bst.insertNode(4);
    bst.insertNode(5);
    bst.insertNode(6);
    bst.insertNode(7);
    try {
        bst.insertNode(4); // Attempt to insertNode duplicate
    } catch (const invalid_argument& e) {
        cout << e.what() << endl;
    }

    cout << "Binary Search Tree (pre-order): ";
    bst.display();

    cout << "Total nodes: " << bst.countNodes() << endl;
    cout << "Total leaves: " << bst.countLeaves() << endl;
    cout << "Height of tree: " << bst.height() << endl;
    cout << "Is tree balanced? " << (bst.isBalanced() ? "Yes" : "No") << endl;

    bst.remove(4);
    cout << "After deleting 4, BST (pre-order): ";
    bst.display();

    bst.destroyTree();
    return 0;
}