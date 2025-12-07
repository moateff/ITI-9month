#include <iostream>
using namespace std;


void printArray(int arr[], int n) {
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

int main() {
    int arr[] = {64, 34, 25, 12, 22, 11, 90};
    int n = sizeof(arr) / sizeof(arr[0]);

    // quickSort(arr, n);
    cout << "Sorted array: ";
    printArray(arr, n);

    return 0;
}