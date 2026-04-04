#include <iostream>
using namespace std;

int binarySearchIterative(int arr[], int n, int target) {
    int left = 0;
    int right = n - 1;

    while (left <= right) {
        int mid = left + (right - left) / 2;

        if (arr[mid] == target) {
            return mid; // Target found at index mid
        } 
        else if (arr[mid] < target) {
            left = mid + 1; // Search in the right half
        } 
        else {
            right = mid - 1; // Search in the left half
        }
    }
    return -1; // Target not found
}

int binarySearchRecursive(int arr[], int left, int right, int target) {
    if (left > right) {
        return -1; // Target not found
    }

    int mid = left + (right - left) / 2;

    if (arr[mid] == target) {
        return mid; // Target found at index mid
    } 
    else if (arr[mid] < target) {
        return binarySearchRecursive(arr, mid + 1, right, target); // Search in the right half
    } 
    else {
        return binarySearchRecursive(arr, left, mid - 1, target); // Search in the left half
    }
}

int binarySearchRecursive(int arr[], int n, int target) {
    return binarySearchRecursive(arr, 0, n - 1, target);
}

int main() {
    int arr[] = {10, 20, 30, 70, 80, 150, 200};
    int n = sizeof(arr) / sizeof(arr[0]);
    int target = 70;

    int result = binarySearchIterative(arr, n, target);
    
    if (result != -1) {
        cout << "Element found at index: " << result << endl;
    } else {
        cout << "Element not found in the array." << endl;
    }

    return 0;
}   