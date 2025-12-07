#include <iostream>
using namespace std;

int linearSearch(int arr[], int n, int target) {
    for (int i = 0; i < n; i++) {
        if (arr[i] == target) {
            return i; // Target found at index i
        } 

        if (arr[i] > target) {
            break; // Since the array is sorted, no need to continue
        }
    }
    return -1; // Target not found
}

int main() {
    int arr[] = {10, 20, 30, 70, 80, 150, 200};
    int n = sizeof(arr) / sizeof(arr[0]);
    int target = 70;

    int result = linearSearch(arr, n, target);
    if (result != -1) {
        cout << "Element found at index: " << result << endl;
    } else {
        cout << "Element not found in the array." << endl;
    }

    return 0;
}   