#include <iostream>
using namespace std;

void swap(int& x, int& y) {
    int temp = x;
    x = y;
    y = temp;
}

void cyclicSort(int arr[], int n) {
    int i = 0;
    while (i < n) {
        int correct = arr[i] - 1;
        if (arr[i] != arr[correct]) {
            swap(arr[i], arr[correct]);
        } else {
            i++;
        }
    }
}

void printArray(int arr[], int n) {
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

int main() {
    int arr[] = {3, 5, 2, 1, 4};
    int n = sizeof(arr) / sizeof(arr[0]);

    cyclicSort(arr, n);
    cout << "Sorted array: ";
    printArray(arr, n);

    return 0;
}